using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Repositories.Interfaces;
using APARTMENT_API.Services.Interfaces;
using APARTMENT_API.Exceptions;
using AutoMapper;
using APARTMENT_API.Model;

namespace APARTMENT_API.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public UserRoleService(
            IMapper mapper,
            IUserRoleRepository repository,
            IUserRepository userRepository,
            IRoleRepository roleRepository
        ){
            _mapper = mapper;
            _repository = repository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public async Task<UserRoleResDto?> GetUserRoleAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new NotFoundException("Not found");
            }
            var roles = await _repository.GetUserRolesAsync(userId);
            return _mapper.Map<UserRoleResDto>(roles);
        }

        public async Task<bool> AssignRoleAsync(int userId, int roleId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if(user == null)
            {
                throw new NotFoundException("User not found");
            }

            var role = await _roleRepository.GetByIdAsync(roleId);
            if (role == null)
            {
                throw new NotFoundException("Role not found");
            }

            if (role.IsActive != 1)
            {
                throw new InvalidOperationException("Role is inactive");
            }

            var exists = await _repository.HasRoleAsync(userId, roleId);
            if (exists)
            {
                throw new BadRequestException("User already has this role");
            }
            var userRole = new ApplicationUserRole
            {
                UserId = userId,
                RoleId = roleId
            };
            //await _repository.AddUserRolesAsync(userRole);
            await _repository.AddUserRolesAsync(new[] { userRole });
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AssignRoleAsync(int userId, List<int> roleIds)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            if(roleIds == null || roleIds.Count == 0)
            {
                throw new NotFoundException("At least one role is required");
            }

            roleIds = roleIds.Distinct().ToList();
            var newRoles = new List<ApplicationUserRole>();
            foreach (var roleId in roleIds)
            {
                var role = await _roleRepository.GetByIdAsync(roleId);
                if (role == null)
                    throw new NotFoundException($"Role ID {roleId} not found.");

                if (role.IsActive != 1)
                    throw new InvalidOperationException($"Role '{role.Name}' is inactive.");

                var exists = await _repository.HasRoleAsync(userId, roleId);
                if (!exists)
                {
                    newRoles.Add(new ApplicationUserRole { UserId = userId, RoleId = roleId });
                }
            }

            if (newRoles.Count == 0)
                throw new BadRequestException("No roles assign.");

            await _repository.AddUserRolesAsync(newRoles);
            await _repository.SaveChangesAsync();

            return true;
        }

        

        public async Task<bool> RemoveRelesAsync(int userId, List<int> roleIds)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                throw new NotFoundException("User not found.");

            roleIds ??= [];
            roleIds = roleIds.Distinct().ToList();

            foreach (var roleId in roleIds)
            {
                var role = await _roleRepository.GetByIdAsync(roleId);
                if (role == null)
                    throw new NotFoundException($"Role ID {roleId} not found.");
                if (role.IsActive != 1)
                    throw new InvalidOperationException($"Role '{role.Name}' is inactive.");
            }

            var existingRoles = await _repository.GetUserRoleEntitiesAsync(userId);
            if (existingRoles.Count > 0)
            {
                _repository.RemoveUserRoles(existingRoles);
            }

            if (roleIds.Count > 0)
            {
                var newRoles = roleIds.Select(roleId => new ApplicationUserRole { UserId = userId, RoleId = roleId });
                await _repository.AddUserRolesAsync(newRoles);
            }

            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveRoleAsync(int userId, int roleId)
        {
            //var userRole = await _repository.GetUserRoleAsync(userId, roleId);
            var userRole = await _repository.GetUserRoleAsync(userId, roleId);

            if (userRole == null)
                throw new BadRequestException("User role not found.");

            _repository.RemoveUserRole(userRole);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
