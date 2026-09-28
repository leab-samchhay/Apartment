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
    public class OrtherExpensController : ControllerBase
    {
        private readonly IOrtherExpenseService _OrtherExpensService;
        public OrtherExpensController(IOrtherExpenseService ortherExpensService)
        {
            _OrtherExpensService = ortherExpensService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrtherExpenseAsync(int page = 1 ,  int pageSize = 10)
        {
            var data = await _OrtherExpensService.GetOrtherExpenseAsync(page, pageSize);
            return ApiResponse.Success(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrtherExpensByIdAsync(int id)
        {
            var data = await _OrtherExpensService.GetOrtherExpenseByIdAsync(id);
            return ApiResponse.Success(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrtherExpenseResDto ortherExpenseRes)
        {
            var data = await _OrtherExpensService.CreateOrtherExpenseAsync(ortherExpenseRes);
            return ApiResponse.Success(data);
        }

        [HttpPut]
        public async Task<IActionResult> Put (int id, OrtherExpenseResDto ortherExpenseResDto)
        {
            var data = await _OrtherExpensService.UpdateOrtherExpenseAsync(id, ortherExpenseResDto);
            return ApiResponse.Success(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete (int id)
        {
            await _OrtherExpensService.DeleteOrtherExpensAsync(id);
            return ApiResponse.Success(new { }, $"Delete OrtherExpns id {id} SuccessFull.");
        }
    }
}
