using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Helpers;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APARTMENT_API.Services.Interfaces
{
    public interface IOrtherExpenseService
    {
        Task<PagedResult<OrtherExpenseResDto>> GetOrtherExpenseAsync(int page = 1, int paseSize = 10);
        Task<List<OrtherExpenseResDto>> GetAllOrtherExpenseAsync();
        Task<OrtherExpenseResDto> GetOrtherExpenseByIdAsync(int id);
        Task<OrtherExpenseResDto> CreateOrtherExpenseAsync(OrtherExpenseResDto ortherExpense);
        Task<OrtherExpenseResDto> UpdateOrtherExpenseAsync(int id, OrtherExpenseResDto ortherExpenseResDto);
        Task<bool> DeleteOrtherExpensAsync(int id);
    }
}
