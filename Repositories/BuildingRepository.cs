using APARTMENT_API.Configurations;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APARTMENT_API.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly ApplicationDbContext _context;
        public BuildingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<Building>> GetBuildings(int page = 1, int pageize = 10)
        {
            var data = await _context.TblBuilding.ToPagedResultAsync(page, pageize);
            return data;
        }

        public async Task<List<Building>> GetAllBuildings()
        {
            return await _context.TblBuilding.ToListAsync();
        }
        public async Task<Building> GetBuilding(int id)
        {
            var data = await _context.TblBuilding.FindAsync(id);
            return data!;
        }
        public async Task<Building> Create(Building building)
        {
            await _context.TblBuilding.AddAsync(building);
            await _context.SaveChangesAsync();
            return building;
        }
        public async Task<Building> Update(Building building)
        {
            _context.TblBuilding.Update(building);
            await _context.SaveChangesAsync();
            return building;
        }
        public async Task<bool> Delete(Building building)
        {
            _context.TblBuilding.Remove(building);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
