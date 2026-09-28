using APARTMENT_API.Configurations;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APARTMENT_API.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationRole>> GetAllAsync()
        {
            return await _context.TblApplicationRole
                  .AsNoTracking()
                  .OrderBy(x => x.Name)
                  .ToListAsync();
        }

        public async Task<ApplicationRole?> GetByIdAsync(int id)
        {
            return await _context.TblApplicationRole
                .FirstOrDefaultAsync(x  => x.Id == id);
        }

        public async Task<ApplicationRole?> GetByNameAsync(string name)
        {
            return await _context.TblApplicationRole
                .FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            var data = await _context.TblApplicationRole
                .AnyAsync(x => x.Name == name);
            return data;
        }

        public async Task<bool> ExistsByNameAsync(string name, int excludeId)
        {
            return await _context.TblApplicationRole
                .AnyAsync(x =>
                x.Name == name && x.Id != excludeId);
        }

        public async Task AddAsync(ApplicationRole role)
        {
            await _context.TblApplicationRole.AddAsync(role);
        }

        public void Update(ApplicationRole role)
        {
           _context.TblApplicationRole.Update(role);
        }

        public void Delete(ApplicationRole role)
        {
            _context.TblApplicationRole.Remove(role);
        }


        public async Task<bool> HasUsersAsync(int rolseId)
        {
            return await _context.TblApplicationUserRole
                .AnyAsync(x => x.RoleId == rolseId);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        
    }
}
