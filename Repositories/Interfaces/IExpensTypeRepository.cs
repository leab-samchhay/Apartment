using APARTMENT_API.Helpers;
using APARTMENT_API.Model;

namespace APARTMENT_API.Repositories.Interfaces
{
    public interface IExpensTypeRepository
    {
        Task<PagedResult<ExpensType>> GetExpensTypeAsync(int page = 1, int pageSize = 10);
        Task<List<ExpensType>> GetAllExpensTypeAsync();
        Task<ExpensType> GetExpensTypeByIdAsync(int id);
        Task<ExpensType> CreateExpensTypeAsync(ExpensType expensType);
        Task<ExpensType> UpdateExpensTypeAsync(ExpensType expensType);
        Task<bool> DeleteAsync(ExpensType expensType);
    }
}
