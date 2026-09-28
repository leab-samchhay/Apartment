using APARTMENT_API.Model;
using APARTMENT_API.Helpers;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APARTMENT_API.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<PagedResult<Item>> GetItemAsync(int page = 1, int pageSize = 10);
        Task<List<Item>> GetAllItemAsync();
        Task<Item> GetItemByIdAsync(int itemId);
        Task<Item> CreateItemAsync(Item item);
        Task<Item> UpdateItemAsync(Item item);
        Task<bool> DeleteItemAsync(Item item);
    }
}
