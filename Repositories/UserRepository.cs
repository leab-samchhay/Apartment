using APARTMENT_API.Configurations;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APARTMENT_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<ApplicationUser>> GetUserByPageAsync(int page = 1, int pageSize = 10)
        {
            var data = await _context.TblApplicationUser.ToPagedResultAsync(page, pageSize);
            return data;
        }
        public async Task<List<ApplicationUser>> GetUsersAsync()
        {
            var data = await _context.TblApplicationUser.ToListAsync();
            return data;
        }
        public async Task<ApplicationUser?> GetUserByIdAsync(int userId)
        {
            var data = await _context.TblApplicationUser.FirstOrDefaultAsync(x => x.Id == userId);
            return data;
        }
        public async Task<ApplicationUser?> GetUserByNameAsync(string username)
        {
            username = username.Trim().ToLowerInvariant();
            var data = await _context.TblApplicationUser.FirstOrDefaultAsync(x => x.Username == username);
            return data;
        }

        public async Task<ApplicationUser?> GetUserByEmailAsync(string email)
        {
            var emailExists = await _context.TblApplicationUser.FirstOrDefaultAsync(x => x.Email == email.Trim().ToLowerInvariant());
            return emailExists;
        }

        public async Task<ApplicationUser?> Login(ApplicationUser request)
        {
            var data = await _context.TblApplicationUser
                .FirstOrDefaultAsync(x => 
                x.Username == request.Username && 
                x.PasswordHash == request.PasswordHash);
            return data;
        }

        public async Task<ApplicationUser> Retister(ApplicationUser request)
        {
            await _context.TblApplicationUser.AddAsync(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<ApplicationUser> Update(ApplicationUser request)
        {
            _context.TblApplicationUser.Update(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _context.TblApplicationUser.FindAsync(id);
            if (user == null) return false;
            _context.TblApplicationUser.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
