using APARTMENT_API.Configurations;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APARTMENT_API.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ApplicationRole>> GetUserRolesAsync(int userId)
        {
            return await _context.TblApplicationUserRole
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(x => x.Role)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
        public async Task<ApplicationUserRole?> GetUserRoleAsync(int userId, int roleId)
        {
            return await _context.TblApplicationUserRole
                .FirstOrDefaultAsync(x =>
                x.UserId == userId &&
                x.RoleId == roleId);
        }
        public async Task<List<ApplicationUserRole>> GetUserRoleEntitiesAsync(int userId)
        {
            return await _context.TblApplicationUserRole
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }
        public async Task<bool> HasRoleAsync(int userId, int roleId)
        {
            return await _context.TblApplicationUserRole
                .AnyAsync(x => x.UserId == userId &&
                x.RoleId == roleId);
        }

        public async Task AddUserRoleAsync(ApplicationUserRole userRole)
        {
            await _context.TblApplicationUserRole.AddAsync(userRole);
        }

        public async Task AddUserRolesAsync(IEnumerable<ApplicationUserRole> userRoles)
        {
            await _context.TblApplicationUserRole.AddRangeAsync(userRoles);
        }
        public void RemoveUserRole(ApplicationUserRole userRole)
        {
            _context.TblApplicationUserRole.Remove(userRole);
        }

        public void RemoveUserRoles(IEnumerable<ApplicationUserRole> userRoles)
        {
            _context.TblApplicationUserRole.RemoveRange(userRoles);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ApplicationUserRole>> GetAllUserRolesAsync()
        {
            return await _context.TblApplicationUserRole
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
