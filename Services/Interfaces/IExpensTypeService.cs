using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Helpers;

namespace APARTMENT_API.Services.Interfaces
{
    public interface IExpensTypeService
    {
        Task<PagedResult<ExpensTypeResDto>> GetExpensTypeAsync(int page = 1, int pagesize = 10);
        Task<List<ExpensTypeResDto>> GetAllExpensTypeAsync();
        Task<ExpensTypeResDto> GetExpensTypeByIdAsync(int id);
        Task<ExpensTypeResDto> CreateExpensTypeAsync(ExpensTypeResDto expensTypeResDto);
        Task<ExpensTypeResDto> UpdateExpensTypeAsync(int id, ExpensTypeResDto expensTypeResDto);
        Task<bool> DeleteExpensTypeAsync(int id);
    }
}
