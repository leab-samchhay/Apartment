using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.Helpers;
using APARTMENT_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APARTMENT_API.Controllers
{
    [Route("api/user-roles")]
    [ApiController]
    [Authorize]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;
        private readonly APARTMENT_API.Repositories.Interfaces.IUserRoleRepository _repository;

        public UserRolesController(IUserRoleService userRoleService, APARTMENT_API.Repositories.Interfaces.IUserRoleRepository repository)
        {
            _userRoleService = userRoleService;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userRoles = await _repository.GetAllUserRolesAsync();
            var result = userRoles.Select(ur => new {
                id = ur.UserId * 10000 + ur.RoleId,
                userId = ur.UserId,
                roleId = ur.RoleId
            }).ToList();
            return ApiResponse.Success(result);
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var userId = id / 10000;
            var roleId = id % 10000;
            var result = await _userRoleService.RemoveRoleAsync(userId, roleId);
            return ApiResponse.Success(result, "Deleted successfully");
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleReqDto request)
        {
            var result = await _userRoleService.AssignRoleAsync(request.UserId, request.RoleId);
            return ApiResponse.Success(new { }, "Role assigned successfully.");
        }
        [HttpPost("assign-multiple")]
        public async Task<IActionResult> AssignRoles([FromBody] AssignRolesReqDto request)
        {
            var result = await _userRoleService.AssignRoleAsync(request.UserId, request.RoleIds);
            return ApiResponse.Success(new { }, "Roles assigned successfully.");
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveRole([FromBody] AssignRoleReqDto request)
        {
            var result = await _userRoleService.RemoveRoleAsync(request.UserId, request.RoleId);
            return ApiResponse.Success(new { }, "Role removed successfully.");
        }

        [HttpDelete("remove-multiple")]
        public async Task<IActionResult> RemovesRole([FromBody] AssignRoleReqDto request)
        {
            var result = await _userRoleService.RemoveRoleAsync(request.UserId, request.RoleId);
            return ApiResponse.Success(new { }, "Role removed successfully.");
        }
    }
}
