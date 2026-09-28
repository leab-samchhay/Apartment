using APARTMENT_API.Helpers;
using APARTMENT_API.Model;

namespace APARTMENT_API.Repositories.Interfaces
{
    public interface IPayslipRepository
    {
        Task<PagedResult<Payslip>> GetPayslipAsync(int page = 1, int pageSize = 10);
        Task<List<Payslip>> GetAllPayslipAsync();
        Task<Payslip?> GetPayslipByIdAsync(int id);
        Task<Payslip> CreatePayslipAsync(Payslip payslip);
        Task<Payslip> UpdatePayslipAsync(Payslip payslip);
        Task<bool> DeletePayslipAsync(Payslip payslip);
    }
}
