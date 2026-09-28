using APARTMENT_API.Model;
using APARTMENT_API.Helpers;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APARTMENT_API.Repositories.Interfaces
{
    public interface IPositionRepository
    {
        Task<PagedResult<Position>> GetPositionAsync(int page = 1, int pageSize = 10);
        Task<List<Position>> GetAllPositionAsync();
        Task<Position> GetPositionByIdAsync(int id);
        Task<Position> CreatePositionAsync(Position position);
        Task<Position> UpdatePositionAsync(Position position);
        Task<bool> DeletePositionAsync(Position position);
    }
}
