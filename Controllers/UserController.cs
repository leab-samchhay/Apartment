using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.Helpers;
using APARTMENT_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APARTMENT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterReqDto request)
        {
            var data = await _service.Retister(request);
            return ApiResponse.Success(data, "Register successfully");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReqDto request)
        {
            var data = await _service.Login(request);
            return ApiResponse.Success(data, "Login successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var data = await _service.GetUsersByPageAsync(page, pageSize);
            return ApiResponse.Success(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RegisterReqDto request)
        {
            var data = await _service.UpdateUserAsync(id, request);
            return ApiResponse.Success(data, "Updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteUserAsync(id);
            return ApiResponse.Success(new { }, "Deleted successfully");
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username = User.FindFirstValue(ClaimTypes.Name);
            var email = User.FindFirstValue(ClaimTypes.Email);
            var fullName = User.FindFirstValue("FullName");
            var roles = User.FindAll(ClaimTypes.Role).Select(x => x.Value).ToList();
            return ApiResponse.Success(new
            {
                userId,
                username,
                email,
                fullName,
                roles
            });
        }
    }
}
