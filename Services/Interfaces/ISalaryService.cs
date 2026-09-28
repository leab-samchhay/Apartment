using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Helpers;

namespace APARTMENT_API.Services.Interfaces
{
    public interface ISalaryService
    {
        Task<PagedResult<SalaryResDto>> GetSalaryAsync(int page =1 , int pageSize = 10);
        Task<List<SalaryResDto>> GetAllAsync();
        Task<SalaryResDto> GetSalaryByIdAsync(int id);
        Task<SalaryResDto> CreateSalaryAsync(SalaryReqDto salary);
        Task<SalaryResDto> UpdateSalaryAsync(int id, SalaryReqDto salary);
        Task<bool> DeleteSalaryAsync(int id);
    }
}
