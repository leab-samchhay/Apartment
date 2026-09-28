namespace APARTMENT_API.DTOs.Responses
{
    public class StaffResDto
    {
        public int Id { get; set; }
        public int? positionId { get; set; }
        public string? name { get; set; }
        public string? nameKh { get; set; }
        public string? sex { get; set; }
        public DateTime? dob { get; set; }
        public string? phone { get; set; }
        public string? address { get; set; }
        public string? email { get; set; }
        public string? identityNo { get; set; }
        public string? photo { get; set; }
        public int? status { get; set; }
        public DateTime? createAt { get; set; }
        public string? createBy{get; set;} 
    }
}
