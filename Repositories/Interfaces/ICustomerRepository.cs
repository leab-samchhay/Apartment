using APARTMENT_API.Helpers;
using APARTMENT_API.Model;

namespace APARTMENT_API.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<PagedResult<Customer>> GetAll(int page = 1 , int pageSize = 10);
        Task<List<Customer>> GetList();
        Task<Customer> GetBuyId (int id);
        Task<int> GetMaxId();
        Task<Customer> Create (Customer req);
        Task<Customer> Update(Customer req);
        Task<bool> Delete (Customer req);
    }
}
