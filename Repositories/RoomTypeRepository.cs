using APARTMENT_API.Configurations;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APARTMENT_API.Repositories
{
    public class RoomTypeRepository : IRoomType
    {
        private readonly ApplicationDbContext _context;

        public RoomTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get RoomType with Pagination
        public async Task<PagedResult<RoomType>> GetRoomType(int page = 1, int pageSize = 10)
        {
            return await _context.TblRoomType.ToPagedResultAsync(page, pageSize);
        }

        // Get All RoomType
        public async Task<List<RoomType>> GetAllRoomType()
        {
            return await _context.TblRoomType.ToListAsync();
        }

        // Get RoomType By Id
        public async Task<RoomType?> GetRoomTypeById(int id)
        {
            return await _context.TblRoomType.FindAsync(id);
        }

        // Create RoomType
        public async Task<RoomType> Create(RoomType roomType)
        {
            await _context.TblRoomType.AddAsync(roomType);
            await _context.SaveChangesAsync();

            return roomType;
        }

        // Update RoomType
        public async Task<RoomType> Update(RoomType roomType)
        {
            _context.TblRoomType.Update(roomType);
            await _context.SaveChangesAsync();

            return roomType;
        }

        // Delete RoomType
        public async Task<bool> Delete(RoomType roomType)
        {
            _context.TblRoomType.Remove(roomType);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}