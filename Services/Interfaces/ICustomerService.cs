using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Helpers;

namespace APARTMENT_API.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<PagedResult<CustomerResDto>> GetlAll (int page = 1 , int pageSize = 10);
        Task<List<CustomerResDto>> GetList();
        Task<CustomerResDto> GetById (int id);
        Task<CustomerResDto> Create (CustomerReqDto CustomerReq);
        Task<CustomerResDto> Update(int id, CustomerReqDto CuStomerReq);
        Task<bool> Delete (int id);
    }
}
