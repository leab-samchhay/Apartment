using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Helpers;
using APARTMENT_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APARTMENT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayslipController : ControllerBase
    {
        private readonly IPayslipService _payslipService;

        public PayslipController(IPayslipService payslipService)
        {
            _payslipService = payslipService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPayslipAsync(int page = 1, int pageSize = 10)
        {
            var data = await _payslipService.GetPayslipAsync(page, pageSize);
            return ApiResponse.Success(data);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetPayslipAllAsync()
        {
            var data = await _payslipService.GetAllAsync();
            return ApiResponse.Success(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayslipById(int id)
        {
            var data = await _payslipService.GetPayslipByIdAsync(id);
            return ApiResponse.Success(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PayslipReqDto payslip)
        {
            var data = await _payslipService.CreatePayslipAsync(payslip);
            return ApiResponse.Success(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PayslipReqDto payslip)
        {
            var data = await _payslipService.UpdatePayslipAsync(id, payslip);
            return ApiResponse.Success(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _payslipService.DeletePayslipAsync(id);
            return ApiResponse.Success(data);
        }
    }
}
