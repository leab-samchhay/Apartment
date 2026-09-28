using APARTMENT_API.DTOs.Responses;

namespace APARTMENT_API.Services.Interfaces
{
    public interface IUserRoleService
    {
        Task<UserRoleResDto?> GetUserRoleAsync(int userId);
        Task<bool> AssignRoleAsync (int userId, int roleId);
        Task<bool> AssignRoleAsync (int userId,List<int> roleIds);
        Task<bool> RemoveRoleAsync (int userId, int roleId);
        Task<bool> RemoveRelesAsync(int userId, List<int> roleIds);
    }
}
