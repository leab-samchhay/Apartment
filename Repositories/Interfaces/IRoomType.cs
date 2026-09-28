using APARTMENT_API.Helpers;
using APARTMENT_API.Model;

namespace APARTMENT_API.Repositories.Interfaces
{
    public interface IRoomType
    {
        Task<PagedResult<RoomType>> GetRoomType(int page = 1, int pageSize = 10);

        Task<List<RoomType>> GetAllRoomType();

        Task<RoomType?> GetRoomTypeById(int id);

        Task<RoomType> Create(RoomType roomType);

        Task<RoomType> Update(RoomType roomType);

        Task<bool> Delete(RoomType roomType);
    }
}