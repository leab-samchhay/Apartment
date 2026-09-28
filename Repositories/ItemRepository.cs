using APARTMENT_API.Configurations;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace APARTMENT_API.Repositories
{
    public class ItemRepository:IItemRepository
    {
        public readonly ApplicationDbContext _context;
        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Item>> GetItemAsync(int page =1, int pageSize = 10)
        {
            var data = await _context.TblItem.ToPagedResultAsync(page, pageSize);
            return data;
        }

        public async Task<List<Item>> GetAllItemAsync()
        {
            var data = await _context.TblItem.ToListAsync();
            return data;
        }

        public async Task<Item> GetItemByIdAsync(int itemId)
        {
            var data = await _context.TblItem.FindAsync(itemId);
            return data!;
        }

        public async Task<Item> CreateItemAsync(Item item)
        {
            await _context.TblItem.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> UpdateItemAsync(Item item)
        {
            _context.TblItem.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            _context.TblItem.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
