using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;

namespace APARTMENT_API.Services.Interfaces
{
    public interface IAuthorizationService
    {
        Task<AuthResDto> Login(AuthReqDto req);
    }
}
