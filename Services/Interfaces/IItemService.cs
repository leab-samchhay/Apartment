using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Model;
using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.Helpers;

namespace APARTMENT_API.Services.Interfaces
{
    public interface IItemService
    {
        Task<PagedResult<ItemResDto>> GetItemAsync(int page = 1, int pageSize = 10);
        Task<List<ItemResDto>> GetAllItemAsync();
        Task<ItemResDto> GetItemByIdAsync(int itemId);
        Task<ItemResDto> CreateItemAsync (ItemReqDto item);
        Task<ItemResDto> UpdateItemAsync(int itemId, ItemReqDto item);
        Task<bool> Delete(int itemId);
    }
}
