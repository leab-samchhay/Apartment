namespace APARTMENT_API.DTOs.Requests
{
    public class RoleReqDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int IsActive { get; set; }
    }
}
