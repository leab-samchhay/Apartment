using APARTMENT_API.DTOs.Requests;
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
    public class ExpensTypeController : ControllerBase
    {
        private readonly IExpensTypeService _expens;

        public ExpensTypeController(IExpensTypeService expens)
        {
            _expens = expens;
        }
        [HttpGet]
        public async Task<IActionResult> GetBuildins(int page = 1, int pageSize = 10)
        {
            var data = await _expens.GetExpensTypeAsync(page, pageSize);
            return ApiResponse.Success(data);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _expens.GetAllExpensTypeAsync();
            return ApiResponse.Success(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBuildin(int id)
        {
            var data = await _expens.GetExpensTypeByIdAsync(id);
            return ApiResponse.Success(data);
        }
        [HttpPost]
        public async Task<IActionResult> Post(ExpensTypeResDto expensTypeResDto)
        {
            var data = await _expens.CreateExpensTypeAsync(expensTypeResDto);
            return ApiResponse.Success(data);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, ExpensTypeResDto expensTypeResDto)
        {
            var data = await _expens.UpdateExpensTypeAsync(id, expensTypeResDto);
            return ApiResponse.Success(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _expens.DeleteExpensTypeAsync(id);
            return ApiResponse.Success(new { }, $"Delete building id {id} successfully.");
        }
    }
}
