using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.Helpers;

namespace APARTMENT_API.Services.Interfaces
{
    public interface IStaffService
    {
        Task<PagedResult<StaffResDto>> GetStaffAsync(int page = 1 , int pageSize = 10);
        Task<List<StaffResDto>> GetAllStaffAsync();
        Task<StaffResDto> GetStaffByIdAsync(int id);
        Task<StaffResDto> CreateStaffAsync(StaffReqDto staffReqDto);
        Task<StaffResDto> UpdateStaffAsync(int id, StaffReqDto staffReqDto);
        Task<bool> DeleteStaffAsync(int id);
    }
}
