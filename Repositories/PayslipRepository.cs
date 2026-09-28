using APARTMENT_API.Configurations;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APARTMENT_API.Repositories
{
    public class PayslipRepository : IPayslipRepository
    {
        private readonly ApplicationDbContext _context;
        public PayslipRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Payslip>> GetPayslipAsync(int page = 1, int pageSize = 10)
        {
            var data = await _context.TblPayslip.ToPagedResultAsync(page, pageSize);
            return data;
        }

        public async Task<List<Payslip>> GetAllPayslipAsync()
        {
            var data = await _context.TblPayslip.ToListAsync();
            return data;
        }

        public async Task<Payslip?> GetPayslipByIdAsync(int id)
        {
            var data = await _context.TblPayslip.FindAsync(id);
            return data;
        }

        public async Task<Payslip> CreatePayslipAsync(Payslip payslip)
        {
            await _context.TblPayslip.AddAsync(payslip);
            await _context.SaveChangesAsync();
            return payslip;
        }

        public async Task<Payslip> UpdatePayslipAsync(Payslip payslip)
        {
            _context.TblPayslip.Update(payslip);
            await _context.SaveChangesAsync();
            return payslip;
        }

        public async Task<bool> DeletePayslipAsync(Payslip payslip)
        {
            _context.TblPayslip.Remove(payslip);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
