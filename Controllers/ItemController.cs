using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.Helpers;
using APARTMENT_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APARTMENT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAction(int page = 1, int pageSize = 10)
        {
            var data = await _itemService.GetItemAsync(page, pageSize);
            return ApiResponse.Success(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAction (int id)
        {
            var data = await _itemService.GetItemByIdAsync(id);
            return ApiResponse.Success(data);
        }
        [HttpPost]
        public async Task<IActionResult> Post(ItemReqDto req)
        {
            var data = await _itemService.CreateItemAsync(req);
            return ApiResponse.Success(data);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int itemId, ItemReqDto item)
        {
            var data = await _itemService.UpdateItemAsync(itemId, item);
            return ApiResponse.Success(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _itemService.Delete(id);
            return ApiResponse.Success(new { }, $"Item with ID {id} has been deleted successfully.");
        }
    }
}
