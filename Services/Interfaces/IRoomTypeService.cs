using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Helpers;

namespace APARTMENT_API.Services.Interfaces
{
    public interface IRoomTypeService
    {
        Task<PagedResult<RoomTypeResDto>> GetRoomType(int page = 1, int pageSize = 10);

        Task<List<RoomTypeResDto>> GetAllRoomType();

        Task<RoomTypeResDto?> GetRoomTypeById(int id);

        Task<RoomTypeResDto> Create(RoomTypeReqDto roomType);

        Task<RoomTypeResDto> Update(int id, RoomTypeReqDto roomType);

        Task<bool> Delete(int id);
    }
}