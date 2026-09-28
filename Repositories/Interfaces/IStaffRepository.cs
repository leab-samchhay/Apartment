using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APARTMENT_API.Repositories.Interfaces
{
    public interface IStaffRepository
    {
        Task<PagedResult<Staff>> GetStaffAsync(int page = 10, int pageSize = 10);
        Task<List<Staff>> GetAllStaffListAsync();
        Task<Staff> GetStaffByIdAsync(int id);
        Task<Staff> CreateStaffAsync (Staff staff);
        Task<Staff> UpdateStaffAsync (Staff staff);
        Task<bool> DeleteStaffAsync (Staff staff);
    }
}
