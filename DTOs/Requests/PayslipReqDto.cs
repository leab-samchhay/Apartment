namespace APARTMENT_API.DTOs.Requests
{
    public class PayslipReqDto
    {
        public DateTime date { get; set; }
        public int staffId { get; set; }
        public decimal salary { get; set; }
        public decimal vat { get; set; }
        public decimal penanty { get; set; }
        public decimal bonus { get; set; }
        public decimal totalsalary { get; set; }

        public DateTime? createdate { get; set; }
        public string? createby { get; set; }
    }
}
