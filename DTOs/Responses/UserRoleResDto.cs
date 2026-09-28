namespace APARTMENT_API.DTOs.Responses
{
    public class UserRoleResDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public List<RoleResDto> Roles { get; set; } = [];
    }
}
