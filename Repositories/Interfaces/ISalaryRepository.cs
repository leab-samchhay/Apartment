using APARTMENT_API.Helpers;
using APARTMENT_API.Model;

namespace APARTMENT_API.Repositories.Interfaces
{
    public interface ISalaryRepository
    {
        Task<PagedResult<Salary>> GetSalaryAsync (int page =1 , int pageSize = 10);
        Task<List<Salary>> GetAllSalaryAsync();
        Task<Salary> GetSalaryByIdAsync(int id);
        Task<Salary> CreateSalaryAsync(Salary salary);
        Task<Salary> UpdateSalaryAsync(Salary salary);
        Task<bool> DeleteSalaryAsync(Salary salary);
    }
}
