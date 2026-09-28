using APARTMENT_API.DTOs.Responses;
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
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _position;

        public PositionController(IPositionService position)
        {
            _position = position;
        }
        [HttpGet]
        public async Task<IActionResult> GetBuildins(int page = 1, int pageSize = 10)
        {
            var data = await _position.GetPositionAsync(page, pageSize);
            return ApiResponse.Success(data);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _position.GetAllPositionAsync();
            return ApiResponse.Success(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBuildin(int id)
        {
            var data = await _position.GetPositionByIdAsync(id);
            return ApiResponse.Success(data);
        }
        [HttpPost]
        public async Task<IActionResult> Post(PositionResDto positionResDto)
        {
            var data = await _position.CreatePositionAsync(positionResDto);
            return ApiResponse.Success(data);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, PositionResDto positionResDto)
        {
            var data = await _position.UpdatePositionAsync(id, positionResDto);
            return ApiResponse.Success(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _position.DeletePositionAsync(id);
            return ApiResponse.Success(new { }, $"Delete building id {id} successfully.");
        }
    }
}
