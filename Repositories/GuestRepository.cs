using APARTMENT_API.Configurations;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APARTMENT_API.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly ApplicationDbContext _context;
        public GuestRepository (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<Guest>> GetGuestPageAsync(int page = 1, int pageSize = 10)
        {
            var data = await _context.TblGuest.ToPagedResultAsync(page, pageSize);
            return data;
        }
        public async Task<List<Guest>> GetGuestAllAsync()
        {
            var data = await _context.TblGuest.ToListAsync();
            return data;
        }
        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            var data = await _context.TblGuest.FindAsync(id);
            return data!;
        }
        public async Task<Guest> CreateGuestAsync(Guest guest)
        {
            await _context.TblGuest.AddAsync(guest);
            await _context.SaveChangesAsync();
            return guest;
        }

        public async Task<Guest> UpdateGuestAsync(Guest guest)
        {
            _context.TblGuest.Update(guest);
            await _context.SaveChangesAsync();
            return guest;
        }
        public async Task<bool> DeleteGuestAsync(Guest guest)
        {
            _context.TblGuest.Remove(guest);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
