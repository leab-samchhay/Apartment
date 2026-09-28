namespace APARTMENT_API.DTOs.Responses
{
    public class UserResDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public int IsActive { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
