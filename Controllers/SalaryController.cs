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
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _salary;
        public SalaryController(ISalaryService salary)
        {
            _salary = salary;
        }
        [HttpGet]
        public async Task<IActionResult> GetSalaryAsync(int page =1, int pagSize =10)
        {
            var data = await _salary.GetSalaryAsync(page, pagSize);
            return ApiResponse.Success(data);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetSalaryAllAsync()
        {
            var data = await _salary.GetAllAsync();
            return ApiResponse.Success(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalaryById(int id)
        {
            var data = await _salary.GetSalaryByIdAsync(id);
            return ApiResponse.Success(data);
        }
        [HttpPost]
        public async Task<IActionResult> Post(SalaryReqDto salary)
        {
            var data = await _salary.CreateSalaryAsync(salary);
            return ApiResponse.Success(data);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,SalaryReqDto salary)
        {
            var data = await _salary.UpdateSalaryAsync(id,salary);
            return ApiResponse.Success(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            var data = await _salary.DeleteSalaryAsync(id);
            return ApiResponse.Success(data);
        }
    }
}
