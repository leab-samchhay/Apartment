using APARTMENT_API.Configurations;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace APARTMENT_API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<Customer>> GetAll(int page = 1, int pageSize = 10)
        {
            var data = await _context.CUSTOMER.ToPagedResultAsync(page, pageSize);
            return data;
        }
        public async Task<List<Customer>> GetList()
        {
            var data = await _context.CUSTOMER.ToListAsync();
            return data;
        }

        public async Task<Customer> GetBuyId(int id)
        {
            var data = await _context.CUSTOMER.FindAsync(id);
            return data!;
        }

        public async Task<int> GetMaxId()
        {
            if (await _context.CUSTOMER.AnyAsync())
            {
                return await _context.CUSTOMER.MaxAsync(c => c.ID);
            }
            return 0;
        }

        public async Task<Customer> Create(Customer req)
        {
            await _context.CUSTOMER.AddAsync(req);
            await _context.SaveChangesAsync();
            return req;
        }
        public async Task<Customer> Update(Customer req)
        {
            _context.CUSTOMER.Update(req);
            await _context.SaveChangesAsync();
            return req;
        }
        public async Task<bool> Delete(Customer req)
        {
            _context.CUSTOMER.Remove(req);
            await _context.SaveChangesAsync() ;
            return true;
        }
    }
}
