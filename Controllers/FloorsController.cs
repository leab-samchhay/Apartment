using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APARTMENT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FloorsController : ControllerBase
    {
        private readonly IFloorsService _floorService;

        public FloorsController(IFloorsService service)
        {
            _floorService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetBuildins(int page = 1, int pageSize = 10)
        {
            var data = await _floorService.GetFloorsAsync(page, pageSize);
            return ApiResponse.Success(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBuildin(int id)
        {
            var data = await _floorService.GetFloorByIdAsync(id);
            return ApiResponse.Success(data);
        }
        [HttpPost]
        public async Task<IActionResult> Post(FloorsReqDto req)
        {
            var data = await _floorService.CreateAsync(req);
            return ApiResponse.Success(data);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, FloorsReqDto req)
        {
            var data = await _floorService.UpdateAsync(id, req);
            return ApiResponse.Success(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _floorService.DeletAsync(id);
            return ApiResponse.Success(new { }, $"Delete floor id {id} successfully.");
        }
    }
}
