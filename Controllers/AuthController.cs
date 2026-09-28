using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.Helpers;
using APARTMENT_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APARTMENT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthorizationService _service;
        public AuthController(IAuthorizationService service)
        {
            _service = service;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthReqDto req)
        {
            var data = await _service.Login(req);
            return ApiResponse.Success(data);
        }
    }
}
