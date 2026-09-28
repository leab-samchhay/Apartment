using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using System.Numerics;

namespace APARTMENT_API.Repositories.Interfaces
{
    public interface IGuestRepository
    {
        Task<PagedResult<Guest>> GetGuestPageAsync (int page = 1 , int  pageSize = 10);
        Task<List<Guest>> GetGuestAllAsync();
        Task<Guest> GetGuestByIdAsync(int id);
        Task<Guest> CreateGuestAsync (Guest guest);
        Task<Guest> UpdateGuestAsync (Guest guest);
        Task<bool> DeleteGuestAsync (Guest guest);
    }
}
