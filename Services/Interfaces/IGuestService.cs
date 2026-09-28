using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Helpers;

namespace APARTMENT_API.Services.Interfaces
{
    public interface IGuestService
    {
        Task<PagedResult<GuestResDto>> GetGuestPageAsync(int page = 1, int pageSize = 10);
        Task<List<GuestResDto>> GetGuestListAsync();
        Task<GuestResDto> GetGuestByIdAsync(int guestId);
        Task<GuestResDto> CreateGuesAsync (GuestReqDto req);
        Task<GuestResDto> UpdateGuesAsync (int id, GuestReqDto req);
        Task<bool> DeleteGuestAsync (int guestId);
    }
}
