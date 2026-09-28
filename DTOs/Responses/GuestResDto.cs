namespace APARTMENT_API.DTOs.Responses
{
    public class GuestResDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameKh { get; set; }
        public string? Sex { get; set; }
        public DateTime? Dob { get; set; }
        public string? Address { get; set; }
        public string? Nationality { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? SSN { get; set; }
        public string? Passport { get; set; }
        public string? Status { get; set; }
        public string? ImagePath { get; set; }
    }
}
