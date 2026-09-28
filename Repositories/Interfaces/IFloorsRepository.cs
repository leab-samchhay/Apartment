using APARTMENT_API.Helpers;
using APARTMENT_API.Configurations;
using APARTMENT_API.Model;

namespace APARTMENT_API.Repositories.Interfaces
{
    public interface IFloorsRepository
    {
        Task<PagedResult<Floors>>GetFloorsAsync(int page=1, int pageSize=10);
        Task<List<Floors>> GetFloorsAllAsync();
        Task<Floors> GetFloorsByIdAsync(int floorsId);
        Task<Floors> CreateAsync(Floors req);
        Task<Floors> UpdateAsync(Floors req);
        Task<bool> DeletAsync(Floors req);
    }
}
