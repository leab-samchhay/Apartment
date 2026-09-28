namespace APARTMENT_API.DTOs.Responses
{
    public class FloorsResDto
    {
        public int id { get; set; }
        public int FloorNo { get; set; }
        public int BuildingId { get; set; }
        public BuildingResDto? Building { get; set; }

    }
}
