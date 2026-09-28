using APARTMENT_API.Configurations;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APARTMENT_API.Repositories
{
    public class FloorRepository:IFloorsRepository
    {
        private readonly ApplicationDbContext _context;
        public FloorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<Floors>> GetFloorsAsync(int page = 1, int pageSize = 10)
        {
            var data = await _context.TblFloors.Include(f=>f.Building).ToPagedResultAsync(page, pageSize);
            return data;
        }
        public async Task<List<Floors>> GetFloorsAllAsync()
        {
            var data = await _context.TblFloors.Include(f => f.Building).ToListAsync();
            return data!;
        }
        public async Task<Floors> GetFloorsByIdAsync(int floorsId)
        {
            var data = await _context.TblFloors.Include(f => f.Building).FirstOrDefaultAsync(f => f.Id == floorsId);
            return data!;
        }
        public async Task<Floors> CreateAsync(Floors req)
        {
            await _context.TblFloors.AddAsync(req);
            await _context.SaveChangesAsync();
            return req;
            
        }
        public async Task<Floors> UpdateAsynce(Floors req)
        {
            _context.TblFloors.Update(req);
            await _context.SaveChangesAsync();
            return req;
        }
        public async Task<bool> DeletAsync(Floors req)
        {
            _context.TblFloors.Remove(req);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Floors> UpdateAsync(Floors req)
        {
            _context.TblFloors.Update(req);
            await _context.SaveChangesAsync();
            return req;
        }
    }
}
