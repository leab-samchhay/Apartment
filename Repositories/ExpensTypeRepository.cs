using APARTMENT_API.Configurations;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APARTMENT_API.Repositories
{
    public class ExpensTypeRepository : IExpensTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public ExpensTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<ExpensType>> GetExpensTypeAsync(int page = 1, int pageSize = 10)
        {
            var data = await _context.TblExpensType.ToPagedResultAsync(page, pageSize);
            return data;
        }

        public async Task<List<ExpensType>> GetAllExpensTypeAsync()
        {
            var data = await _context.TblExpensType.ToListAsync();
            return data;
        }

        public async Task<ExpensType> GetExpensTypeByIdAsync(int id)
        {
            var data = await _context.TblExpensType.FindAsync(id);
            return data!;
        }
        public async Task<ExpensType> CreateExpensTypeAsync(ExpensType expensType)
        {
            await _context.TblExpensType.AddAsync(expensType);
            await _context.SaveChangesAsync();
            return expensType;
        }
        public async Task<ExpensType> UpdateExpensTypeAsync(ExpensType expensType)
        {
            _context.TblExpensType.Update(expensType);
            await _context.SaveChangesAsync();
            return expensType;
        }

        public async Task<bool> DeleteAsync(ExpensType expensType)
        {
            _context.TblExpensType.Remove(expensType);
            await _context.SaveChangesAsync();
            return true;
        }




    }
}
