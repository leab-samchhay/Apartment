using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.Helpers;
using APARTMENT_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APARTMENT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            var data = await _customerService.GetlAll(page, pageSize);
            return ApiResponse.Success(data);
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            var data = await _customerService.GetList();
            return ApiResponse.Success(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBuyId (int id)
        {
            var data = await _customerService.GetById(id);
            return ApiResponse.Success(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerReqDto CustomerReq)
        {
            var data = await _customerService.Create(CustomerReq);
            return ApiResponse.Success(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, CustomerReqDto CuStomerReq)
        {
            var data = await _customerService.Update(id, CuStomerReq);
            return ApiResponse.Success(data);
        }
        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            await _customerService.Delete(id);
            return true;
        }

    }
}
