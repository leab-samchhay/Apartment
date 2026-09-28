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
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staff;
        public StaffController(IStaffService staff)
        {
            _staff = staff;
        }

        [HttpGet]
        public async Task<IActionResult> GetStaffAsync (int page = 1, int pageSize = 10)
        {
            var data = await _staff.GetStaffAsync(page, pageSize);
            return ApiResponse.Success(data);
        }
        [HttpGet("get-All")]
        public async Task<IActionResult> GetAllStaff()
        {
            var data = await _staff.GetAllStaffAsync();
            return ApiResponse.Success(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffByIdAsync(int id)
        {
            var data = await _staff.GetStaffByIdAsync(id);
            return ApiResponse.Success(data);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] StaffReqDto staffReqDto)
        {
            var data = await _staff.CreateStaffAsync(staffReqDto);
            return ApiResponse.Success(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] StaffReqDto staffReqDto)
        {
            var data = await _staff.UpdateStaffAsync(id, staffReqDto);
            return ApiResponse.Success(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _staff.DeleteStaffAsync(id);
            return ApiResponse.Success(new { }, $"Delete RoomType id {id} successfully.");
        }
    }
}
