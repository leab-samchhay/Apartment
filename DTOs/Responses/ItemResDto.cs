namespace APARTMENT_API.DTOs.Responses
{
    public class ItemResDto
    {
        public int Id { get; set; }
        public string? ItemName { get; set; }
        public string? NameKh { get; set; }
        public decimal Price { get; set; }
        public string? Remark { get; set; }
        public string? Status { get; set; }
    }
}
