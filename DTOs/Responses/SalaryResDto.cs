namespace APARTMENT_API.DTOs.Responses
{
    public class SalaryResDto
    {
        public int id { get; set; }
        public int staffId { get; set; }
        public DateTime date { get; set; }
        public decimal salary { get; set; }
        public string? note { get; set; }
        public DateTime? createdate { get; set; }
        public string? createby { get; set; }
    }
}
