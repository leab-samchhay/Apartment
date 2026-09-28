using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Helpers;
using APARTMENT_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APARTMENT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomType;

        public RoomTypeController(IRoomTypeService roomType)
        {
            _roomType = roomType;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoomType(int page = 1, int pageSize = 10)
        {
            var data = await _roomType.GetRoomType(page, pageSize);
            return ApiResponse.Success(data);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllRoomType()
        {
            var data = await _roomType.GetAllRoomType();
            return ApiResponse.Success(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomTypeById(int id)
        {
            var data = await _roomType.GetRoomTypeById(id);
            return ApiResponse.Success(data!);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RoomTypeReqDto roomTypeDto)
        {
            var data = await _roomType.Create(roomTypeDto);
            return ApiResponse.Success(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, RoomTypeReqDto roomTypeDto)
        {
            var data = await _roomType.Update(id, roomTypeDto);
            return ApiResponse.Success(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roomType.Delete(id);
            return ApiResponse.Success(new { }, $"Delete RoomType id {id} successfully.");
        }
    }
}


