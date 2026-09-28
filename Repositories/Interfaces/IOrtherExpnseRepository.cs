using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APARTMENT_API.Repositories.Interfaces
{
    public interface IOrtherExpnseRepository
    {
        Task<PagedResult<OrtherExpense>> GetOrherAsync(int page = 1, int pageSize = 10);
        Task<List<OrtherExpense>> GetAllOrtherAsync();
        Task<OrtherExpense> GetOrtherByAnsync(int OrherExpensId);
        Task<OrtherExpense> CreateOrtherAsnync(OrtherExpense ortherExpense);
        Task<OrtherExpense> UpdateOrtherAsync(OrtherExpense ortherExpense);
        Task<bool> DeleteOrtherAsync(OrtherExpense ortherExpense);
    }
}
