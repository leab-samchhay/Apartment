namespace APARTMENT_API.DTOs.Requests
{
    public class ItemReqDto
    {
        public string? ItemName { get; set; }
        public string? NameKh { get; set; }
        public decimal Price { get; set; }
        public string? Remark { get; set; }
        public string? Status { get; set; }
    }
}
