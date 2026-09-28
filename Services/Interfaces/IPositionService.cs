using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Helpers;

namespace APARTMENT_API.Services.Interfaces
{
    public interface IPositionService
    {
        Task<PagedResult<PositionResDto>> GetPositionAsync(int page =1 , int pagesize = 10);
        Task<List<PositionResDto>> GetAllPositionAsync();
        Task<PositionResDto> GetPositionByIdAsync (int id);
        Task<PositionResDto> CreatePositionAsync(PositionResDto positionResDto);
        Task<PositionResDto> UpdatePositionAsync(int id ,PositionResDto positionResDto);
        Task<bool> DeletePositionAsync(int id);

    }
}
