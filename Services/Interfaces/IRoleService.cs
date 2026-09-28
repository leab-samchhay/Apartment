using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;

namespace APARTMENT_API.Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleResDto>> GetAllAsync();
        Task<RoleResDto?> GetByIdAsync(int id);
        Task<RoleResDto> CreateAsync(RoleReqDto roleReqDto);
        Task<RoleResDto> UpdateAsync(int id, RoleReqDto roleResDto);
        Task<bool> DeleteAsync(int id);
    }
}
