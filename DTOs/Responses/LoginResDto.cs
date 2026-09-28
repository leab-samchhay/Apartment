using APARTMENT_API.Model;

namespace APARTMENT_API.DTOs.Responses
{
    public class LoginResDto
    {
        public UserResDto? User { get; set; }
        public string? Token { get; set; }
        public List<ApplicationRole> Roles { get; set; } = [];
    }
}
