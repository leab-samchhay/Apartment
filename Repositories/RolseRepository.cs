//using APARTMENT_API.Configurations;
//using APARTMENT_API.Helpers;
//using APARTMENT_API.Model;
//using APARTMENT_API.Repositories.Interfaces;
//using Microsoft.EntityFrameworkCore;

//namespace APARTMENT_API.Repositories
//{
//    public class RolseRepository : IRolseRepository
//    {
        
//        private readonly ApplicationDbContext _context;
//        public RolseRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<PagedResult<Rolse>> GetRolseAsynce(int page = 1, int pageSize = 10)
//        {
//            var data = await _context.TblRolse.ToPagedResultAsync(page, pageSize);
//            return data;
//        }
//        public async Task<List<Rolse>> GetRolseAllAsynce()
//        {
//            var data = await _context.TblRolse.ToListAsync();
//            return data;
//        }

//        public async Task<Rolse> GetRolseById(int id)
//        {
//            var data = await _context.TblRolse.FindAsync(id);
//            return data!;
//        }
//        public async Task<Rolse> CreateRolseAsynce(Rolse rolse)
//        {
//            await _context.TblRolse.AddAsync(rolse);
//            await _context.SaveChangesAsync();
//            return rolse;
//        }

       
//        public async Task<Rolse> UpdateRolseAsynce(Rolse rolse)
//        {
//            _context.TblRolse.Update(rolse);
//            await _context.SaveChangesAsync();
//            return rolse;
//        }

//        public async Task<bool> DeleteRolseAsynce(Rolse rolse)
//        {
//            _context.TblRolse.Remove(rolse);
//            await _context.SaveChangesAsync();
//            return true;
//        }
//    }
//}
