using APARTMENT_API.Configurations;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APARTMENT_API.Repositories
{
    public class PositionRopository : IPositionRepository
    {
        private readonly ApplicationDbContext _context;
        public PositionRopository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<Position>> GetPositionAsync(int page = 1, int pageSize = 10)
        {
            var data = await _context.TblPosition.ToPagedResultAsync(page, pageSize);
            return data;
        }

        public async Task<List<Position>> GetAllPositionAsync()
        {
            var data = await _context.TblPosition.ToListAsync();
            return data;
        }

        public async Task<Position> GetPositionByIdAsync(int id)
        {
            var data = await _context.TblPosition.FindAsync(id);
            return data!;
        }

        public async Task<Position> CreatePositionAsync(Position position)
        {
            await _context.AddAsync(position);
            await _context.SaveChangesAsync();
            return position;

        }

        public async Task<Position> UpdatePositionAsync(Position position)
        {
            _context.TblPosition.Update(position);
            await _context.SaveChangesAsync();
            return position;
        }

       
        public async Task<bool> DeletePositionAsync(Position position)
        {
            _context.TblPosition.Remove(position);
            await _context.SaveChangesAsync();
            return true;

        }



    }
}
