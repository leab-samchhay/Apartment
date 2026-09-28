namespace APARTMENT_API.DTOs.Requests
{
    public class OrtherExpenseReqDto
    {
        public DateTime? Date { get; set; }
        public int? ExpenseTypeId { get; set; }
        public decimal? Amount { get; set; }
        public string? Note { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Image {  get; set; }


    }
}
