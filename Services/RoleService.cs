using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Repositories.Interfaces;
using APARTMENT_API.Services.Interfaces;
using AutoMapper;
using APARTMENT_API.Exceptions;

using APARTMENT_API.Model;

namespace APARTMENT_API.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly IMapper _mapper;
        public RoleService(IRoleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<RoleResDto>> GetAllAsync()
        {
            var roles = await _repository.GetAllAsync();
            return _mapper.Map<List<RoleResDto>>(roles);
        }
        public async Task<RoleResDto?> GetByIdAsync(int id)
        {
            var role = await _repository.GetByIdAsync(id);
            if(role == null)
            {
                throw new NotFoundException("Role Not found");
            }
            return _mapper.Map<RoleResDto>(role);
        }
        public async Task<RoleResDto> CreateAsync(RoleReqDto roleReqDto)
        {
            var name = roleReqDto.Name.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Role name is required ");
            }

            var exists = await _repository.ExistsByNameAsync(name);
            if (exists)
            {
                throw new InvalidOperationException("Role name already exists.");

            }
            var role = _mapper.Map<ApplicationRole>(roleReqDto);
            await _repository.AddAsync(role);
            await _repository.SaveChangesAsync();
            return _mapper.Map<RoleResDto>(role);
        }
        public async Task<RoleResDto> UpdateAsync(int id, RoleReqDto roleResDto)
        {
            var role = await _repository.GetByIdAsync(id);
            if (role == null)
            {
                throw new NotFoundException("Role not found");
            }
            var name = roleResDto.Name.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidOperationException("Role name is required.");
            }
            //_mapper.Map<roleResDto>(role);
            _mapper.Map(roleResDto, role);
            _repository.Update(role);
            await _repository.SaveChangesAsync();
            return _mapper.Map<RoleResDto>(role);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var role = await _repository.GetByIdAsync(id);
            if(role == null)
            {
                throw new NotFoundException("Role not found");

            }
            var hasUsers = await _repository.HasUsersAsync(id);
            if (hasUsers)
            {
                throw new InvalidOperationException(
                    "Cannot delete this role because it is assigned to one or more users.");
            }
            _repository.Delete(role);
            await _repository.SaveChangesAsync();
            return true;
        }

        
    }
}
