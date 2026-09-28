using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.Models;

namespace APARTMENT_API.Repositories.Interfaces
{
    public interface IAuthorizationRepository
    {
        Task<User> Login(AuthReqDto rq);
    }
}
