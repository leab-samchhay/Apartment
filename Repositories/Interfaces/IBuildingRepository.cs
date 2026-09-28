using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;

namespace APARTMENT_API.Repositories.Interfaces
{
    public interface IBuildingRepository
    {
        Task<PagedResult<Building>> GetBuildings(int page = 1, int pageSize = 10);
        Task<List<Building>> GetAllBuildings();
        Task<Building> GetBuilding(int id);
        Task<Building> Create(Building building);
        Task<Building> Update(Building building);
        Task<bool> Delete(Building building);

        
    }
}
