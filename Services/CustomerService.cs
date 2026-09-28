using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Exceptions;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories.Interfaces;
using APARTMENT_API.Services.Interfaces;
using AutoMapper;

namespace APARTMENT_API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CustomerResDto>> GetlAll(int page = 1, int pageSize = 10)
        {
            var customer = await _repository.GetAll(page, pageSize);
            if (customer == null)
            {
                throw new Exception("Data not found ");
            }
            return new PagedResult<CustomerResDto>
            {
                PageNumber = customer.PageNumber,
                PageSize = customer.PageSize,
                TotalPages = customer.TotalPages,
                TotalRecords = customer.TotalRecords,
                Data = _mapper.Map<List<CustomerResDto>>(customer.Data)
            };
        }
        public async Task<List<CustomerResDto>> GetList()
        {
            var customer = await _repository.GetList();
            return _mapper.Map<List<CustomerResDto>>(customer);
        }
        public async Task<CustomerResDto> GetById(int id)
        {
            var customer = await _repository.GetBuyId(id);
            return _mapper.Map<CustomerResDto>(customer);
        }
        public async Task<CustomerResDto> Create(CustomerReqDto CustomerReq)
        {
            if (CustomerReq == null)
            {
                throw new BadRequestException("Bad Request");

            }

            var newData = _mapper.Map<CustomerReqDto,Customer>(CustomerReq);
            var restul = await _repository.Create(newData);
            return _mapper.Map<Customer,CustomerResDto>(restul);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _repository.GetBuyId(id);
            if (entity == null)
            {
                throw new NotFoundException("data not found ");
            }
            await _repository.Delete(entity);
            return true;
        }

        

        public async Task<CustomerResDto> Update(int id, CustomerReqDto CuStomerReq)
        {
            var entity = await _repository.GetBuyId(id);
            if (entity == null)
            {
                throw new NotFoundException("data not found ");
            }

            // Map from Request to Entity (Correct Direction)
            _mapper.Map(CuStomerReq, entity);
            var result = await _repository.Update(entity);
            return _mapper.Map<Customer,CustomerResDto>(result);
        }
    }
}
