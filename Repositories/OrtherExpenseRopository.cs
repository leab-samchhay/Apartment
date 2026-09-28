using APARTMENT_API.Configurations;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace APARTMENT_API.Repositories
{
    public class OrtherExpenseRopository : IOrtherExpnseRepository
    {
        private readonly ApplicationDbContext _contect;
        public OrtherExpenseRopository(ApplicationDbContext contect)
        {
            _contect = contect;
        }

        public async Task<PagedResult<OrtherExpense>> GetOrherAsync(int page = 1, int pageSize = 10)
        {
            var data = await _contect.TblortherExpens.ToPagedResultAsync(page, pageSize);
            return data;
        }
        public async Task<List<OrtherExpense>> GetAllOrtherAsync()
        {
            var data = await _contect.TblortherExpens.ToListAsync();
            return data;
        }

        public async Task<OrtherExpense> GetOrtherByAnsync(int OrherExpensId)
        {
            var data = await _contect.TblortherExpens.FindAsync(OrherExpensId);
            return data!;
        }
        public async Task<OrtherExpense> CreateOrtherAsnync(OrtherExpense ortherExpense)
        {
            await _contect.TblortherExpens.AddAsync(ortherExpense);
            await _contect.SaveChangesAsync();
            return ortherExpense;
        }

        public async Task<bool> DeleteOrtherAsync(OrtherExpense ortherExpense)
        {
            _contect.TblortherExpens.Remove(ortherExpense);
            await _contect.SaveChangesAsync();
            return true;

        }

        

        public async Task<OrtherExpense> UpdateOrtherAsync(OrtherExpense ortherExpense)
        {
            _contect.TblortherExpens.Update(ortherExpense);
            await _contect.SaveChangesAsync();
            return ortherExpense;
        }
    }
}
