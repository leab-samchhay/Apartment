using APARTMENT_API.Configurations;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APARTMENT_API.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationDbContext _context;
        public StaffRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<Staff>> GetStaffAsync(int page = 10, int pageSize = 10)
        {
            var data = await _context.TblStaff.ToPagedResultAsync(page, pageSize);
            return data;
        }
        public async Task<List<Staff>> GetAllStaffListAsync()
        {
            var data = await _context.TblStaff.ToListAsync();
            return data;
        }

        public async Task<Staff> GetStaffByIdAsync(int id)
        {
            var data = await _context.TblStaff.FindAsync(id);
            return data!;
        }
        public async Task<Staff> CreateStaffAsync(Staff staff)
        {
            await _context.TblStaff.AddAsync(staff);
            await _context.SaveChangesAsync();
            return staff;
        }

        public async Task<Staff> UpdateStaffAsync(Staff staff)
        {
            _context.TblStaff.Update(staff);
            await _context.SaveChangesAsync();
            return staff;
        }
        public async Task<bool> DeleteStaffAsync(Staff staff)
        {
            _context.TblStaff.Remove(staff);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
