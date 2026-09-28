using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Helpers;

namespace APARTMENT_API.Services.Interfaces
{
    public interface IPayslipService
    {
        Task<PagedResult<PayslipResDto>> GetPayslipAsync(int page = 1, int pageSize = 10);
        Task<List<PayslipResDto>> GetAllAsync();
        Task<PayslipResDto> GetPayslipByIdAsync(int id);
        Task<PayslipResDto> CreatePayslipAsync(PayslipReqDto payslip);
        Task<PayslipResDto> UpdatePayslipAsync(int id, PayslipReqDto payslip);
        Task<bool> DeletePayslipAsync(int id);
    }
}
