using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Exceptions;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Models;
using APARTMENT_API.Repositories.Interfaces;
using APARTMENT_API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APARTMENT_API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        public UserService(
            IUserRepository repository,
            IMapper mapper,
            IUserRoleRepository userRoleRepository, 
            IConfiguration configuration,
            IPasswordHasher<ApplicationUser> passwordHasher
        )
        {
            _repository = repository;
            _mapper = mapper;
            _userRoleRepository = userRoleRepository;
            _configuration = configuration;
            _passwordHasher = passwordHasher;

        }

        public async Task<PagedResult<UserResDto>> GetUsersByPageAsync(int page = 1, int pageSize = 10)
        {
            //var user = await _respository.GetUsersByPageAsync(page, pageSize);
            var user = await _repository.GetUserByPageAsync(page, pageSize);
            if (user == null)
            {
                throw new NotFoundException("Data not found.");
            }
            return new PagedResult<UserResDto>
            {
                PageNumber = user.PageNumber,
                PageSize = user.PageSize,
                TotalRecords = user.TotalRecords,
                TotalPages = user.TotalPages,
                Data = _mapper.Map<List<UserResDto>>(user.Data),
            };
        }

        public async Task<List<UserResDto>> GetUserAsync()
        {
            var data = await _repository.GetUsersAsync();
            return _mapper.Map<List<UserResDto>>(data);
        }

        public async Task<UserResDto?> GetUserByIdAsync(int id)
        {
            var data = await _repository.GetUserByIdAsync(id);
            return _mapper?.Map<UserResDto>(data);
        }

        private string HashPassword(ApplicationUser user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        private PasswordVerificationResult VerifyPassword(ApplicationUser user, string password)
        {
            return _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash ?? "",
                password
            );
        }
        private string CreateToken(ApplicationUser user, List<string> userRoles)
        {
            var claims = new List<Claim>{
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new (ClaimTypes.Name, user.Username),
                new (JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new (ClaimTypes.Email, user.Email ?? ""),
                new ("FullName", user.FullName ?? "")
            };

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole ?? ""));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:ValidIssuer"],
                audience: _configuration["Jwt:ValidAudience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task<LoginResDto> Login(LoginReqDto request)
        {
            var username = request.UserName.Trim().ToLowerInvariant();
            var user = await _repository.GetUserByNameAsync(request.UserName);
            if (user == null)
            {
                throw new BadRequestException("Invalid username or password.");
            }

            if (user.IsActive == 0)
            {
                throw new BadRequestException("Account is inactive.");
            }

            var passwordValid = VerifyPassword(user, request.Password);
            if (passwordValid == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password.");
            }

            var userRoles = await _userRoleRepository.GetUserRolesAsync(user.Id);
            var roles = userRoles.Select(x => x.Name).ToList();
            var token = CreateToken(user, roles);
            var result = new LoginResDto()
            {
                User = _mapper.Map<UserResDto>(user),
                Token = token,
                Roles = userRoles
            };
            return result;
        }

        public async Task<UserResDto> Retister(RegisterReqDto request)
        {
            var username = request.Username.Trim().ToLowerInvariant();
            //var user = await _repository.GetUserByEmailAsync(request.Username);
            var user = await _repository.GetUserByNameAsync(request.Username);
            if (user != null)
            {
                throw new BadRequestException("Username already exists.");
            }

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                var emailExists = await _repository.GetUserByEmailAsync(request.Email);
                if (emailExists != null)
                {
                    throw new BadRequestException("Email already exists.");
                }
            }

            var newUser = _mapper.Map<ApplicationUser>(request);
            newUser.PasswordHash = HashPassword(newUser, request.Password ?? "");
            newUser.IsActive = 1;
            newUser.CreateAt = DateTime.UtcNow;
            await _repository.Retister(newUser);
            return _mapper.Map<UserResDto>(newUser);
        }

        public async Task<UserResDto> UpdateUserAsync(int id, RegisterReqDto request)
        {
            var user = await _repository.GetUserByIdAsync(id);
            if (user == null) throw new NotFoundException("User not found.");

            user.Username = request.Username;
            user.Email = request.Email;
            user.FullName = request.FullName;
            if (!string.IsNullOrEmpty(request.Password))
            {
                user.PasswordHash = HashPassword(user, request.Password);
            }
            
            await _repository.Update(user);
            return _mapper.Map<UserResDto>(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _repository.GetUserByIdAsync(id);
            if (user == null) throw new NotFoundException("User not found.");
            return await _repository.Delete(id);
        }
    }
}
