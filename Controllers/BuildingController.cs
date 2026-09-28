using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.Helpers;
using APARTMENT_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APARTMENT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _building;

        public BuildingController(IBuildingService building)
        {
            _building = building;
        }
        [HttpGet]
        public async Task<IActionResult> GetBuildins(int page = 1, int pageSize = 10)
        {
            var data = await _building.GetBuildings(page, pageSize);
            return ApiResponse.Success(data);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _building.GetAllBuildings();
            return ApiResponse.Success(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBuildin(int id)
        {
            var data = await _building.GetBuilding(id);
            return ApiResponse.Success(data);
        }
        [HttpPost]
        public async Task<IActionResult> Post(BuildingReqDto buildingDto)
        {
            var data = await _building.Create(buildingDto);
            return ApiResponse.Success(data);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id,BuildingReqDto buildingDto)
        {
            var data = await _building.Update(id, buildingDto);
            return ApiResponse.Success(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _building.Delete(id);
            return ApiResponse.Success(new { }, $"Delete building id {id} successfully.");
        }
    }
}

