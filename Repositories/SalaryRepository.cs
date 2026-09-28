using APARTMENT_API.Configurations;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APARTMENT_API.Repositories
{
    public class SalaryRepository : ISalaryRepository
    {
        
        private readonly ApplicationDbContext _context;
        public SalaryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<Salary>> GetSalaryAsync(int page = 1, int pageSize = 10)
        {
            var data = await _context.TblSalary.ToPagedResultAsync(page, pageSize);
            return data;
        }
        public async Task<List<Salary>> GetAllSalaryAsync()
        {
            var data = await _context.TblSalary.ToListAsync();
            return data;
        }

        public async Task<Salary> GetSalaryByIdAsync(int id)
        {
            var data = await _context.TblSalary.FindAsync(id);
            return data!;
        }
        public async Task<Salary> CreateSalaryAsync(Salary salary)
        {
            await _context.TblSalary.AddAsync(salary);
            await _context.SaveChangesAsync();
            return salary;
        }

        
        public async Task<Salary> UpdateSalaryAsync(Salary salary)
        {
            _context.TblSalary.Update(salary);
            await _context.SaveChangesAsync();
            return salary;
        }

        public async Task<bool> DeleteSalaryAsync(Salary salary)
        {
            _context.TblSalary.Remove(salary);
            await _context.SaveChangesAsync();
            return true;
        }



    }
}
