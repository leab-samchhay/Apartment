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
    public class PayslipService : IPayslipService
    {
        private readonly IPayslipRepository _repository;
        private readonly IMapper _mapper;

        public PayslipService(IPayslipRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResult<PayslipResDto>> GetPayslipAsync(int page = 1, int pageSize = 10)
        {
            var payslip = await _repository.GetPayslipAsync(page, pageSize);
            if (payslip == null)
            {
                throw new NotFoundException("Data not found");
            }

            return new PagedResult<PayslipResDto>
            {
                PageNumber = payslip.PageNumber,
                PageSize = payslip.PageSize,
                TotalPages = payslip.TotalPages,
                TotalRecords = payslip.TotalRecords,
                Data = _mapper.Map<List<PayslipResDto>>(payslip.Data)
            };
        }

        public async Task<List<PayslipResDto>> GetAllAsync()
        {
            var data = await _repository.GetAllPayslipAsync();
            return _mapper.Map<List<PayslipResDto>>(data);
        }

        public async Task<PayslipResDto> GetPayslipByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException(new List<string> { "Id must be greater than zero" });
            }

            var payslip = await _repository.GetPayslipByIdAsync(id);
            if (payslip == null)
            {
                throw new NotFoundException("Data not found");
            }
            return _mapper.Map<PayslipResDto>(payslip);
        }

        public async Task<PayslipResDto> CreatePayslipAsync(PayslipReqDto payslip)
        {
            if (payslip == null)
            {
                throw new BadRequestException("BadRequest Data");
            }

            var newdata = _mapper.Map<Payslip>(payslip);


            var result = await _repository.CreatePayslipAsync(newdata);
            return _mapper.Map<PayslipResDto>(result);
        }

        public async Task<PayslipResDto> UpdatePayslipAsync(int id, PayslipReqDto payslip)
        {
            var entity = await _repository.GetPayslipByIdAsync(id);
            if (entity == null)
            {
                throw new NotFoundException("Data not found");
            }

            if (payslip == null)
            {
                throw new BadRequestException("BadRequest Data");
            }


            _mapper.Map(payslip, entity);

            entity.Id = id;
            var result = await _repository.UpdatePayslipAsync(entity);
            return _mapper.Map<PayslipResDto>(result);
        }

        public async Task<bool> DeletePayslipAsync(int id)
        {
            var entity = await _repository.GetPayslipByIdAsync(id);
            if (entity == null)
            {
                throw new NotFoundException("Data NotFound");
            }
            await _repository.DeletePayslipAsync(entity);
            return true;
        }
    }
}
