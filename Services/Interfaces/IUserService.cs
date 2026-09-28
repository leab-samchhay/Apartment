using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Helpers;

namespace APARTMENT_API.Services.Interfaces
{
    public interface IUserService
    {
        Task<PagedResult<UserResDto>> GetUsersByPageAsync(int page = 1, int pageSize = 10);
        Task<List<UserResDto>> GetUserAsync();
        Task<UserResDto?> GetUserByIdAsync(int id);
        Task<LoginResDto> Login (LoginReqDto request);
        Task<UserResDto> Retister (RegisterReqDto request);
        Task<UserResDto> UpdateUserAsync(int id, RegisterReqDto request);
        Task<bool> DeleteUserAsync(int id);
    }
}
