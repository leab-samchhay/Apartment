using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;

namespace APARTMENT_API.Services.Interfaces
{
    public interface IFloorsService
    {
        Task<PagedResult<FloorsResDto>> GetFloorsAsync(int page = 1, int pageSize = 10);
        Task<List<FloorsResDto>> GetFloorsAllAsync();
        Task<FloorsResDto> GetFloorByIdAsync(int floorsId);
        Task<FloorsResDto> CreateAsync(FloorsReqDto req);
        Task<FloorsResDto> UpdateAsync(int id,FloorsReqDto req);
        Task<bool> DeletAsync(int floorsId);
    }
}
