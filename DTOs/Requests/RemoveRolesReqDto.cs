namespace APARTMENT_API.DTOs.Requests
{
    public class RemoveRolesReqDto
    {
        public int UserId { get; set; }
        public List<int> RoleIds { get; set; } = [];
    }
}
