using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Helpers;
using APARTMENT_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APARTMENT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;
        public GuestController (IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGuestPage(int page = 1 , int pageSize = 10)
        {
            var data = await _guestService.GetGuestPageAsync(page, pageSize);
            return ApiResponse.Success(data);
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetGuestAll()
        {
            var data = await _guestService.GetGuestListAsync();
            return ApiResponse.Success(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuestById(int id)
        {
            var data = await _guestService.GetGuestByIdAsync(id);
            return ApiResponse.Success(data);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] GuestReqDto guestResDto)
        {
            var data = await _guestService.CreateGuesAsync(guestResDto);
            return ApiResponse.Success(data);
        }
        [HttpPut]
        public async Task<IActionResult> PUT (int id, [FromForm] GuestReqDto guestResDto)
        {
            var data = await _guestService.UpdateGuesAsync(id, guestResDto);
            return ApiResponse.Success(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _guestService.DeleteGuestAsync(id);
            return ApiResponse.Success(new {}, $"Delete Guest id {id} successfull");
        }
    }
}
