using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;

namespace APARTMENT_API.Services.Interfaces
{
    public interface IBuildingService
    {
        Task<PagedResult<BuildingResDto>> GetBuildings(int page = 1, int pageSize = 10);
        Task<List<BuildingResDto>> GetAllBuildings();
        Task<BuildingResDto> GetBuilding(int id);
        Task<BuildingResDto> Create(BuildingReqDto building);
        Task<BuildingResDto> Update(int id, BuildingReqDto building);
        Task<bool> Delete(int id);
    }
}
