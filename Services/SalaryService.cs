using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Exceptions;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories.Interfaces;
using APARTMENT_API.Services.Interfaces;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APARTMENT_API.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository _repository;
        private readonly IMapper _mapper;
        public SalaryService(ISalaryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedResult<SalaryResDto>> GetSalaryAsync(int page = 1, int pageSize = 10)
        {
            var salary = await _repository.GetSalaryAsync(page, pageSize);
            if (salary == null)
            {
                throw new NotFoundException("data not found");
            }

            return new PagedResult<SalaryResDto>
            {
                PageNumber = salary.PageNumber,
                PageSize = salary.PageSize,
                TotalPages = salary.TotalPages,
                TotalRecords = salary.TotalRecords,
                Data = _mapper.Map<List<SalaryResDto>>(salary.Data)
            };
        }
        public async Task<List<SalaryResDto>> GetAllAsync()
        {
            var data = await _repository.GetAllSalaryAsync();
            return _mapper.Map<List<SalaryResDto>>(data);
        }

        public async Task<SalaryResDto> GetSalaryByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException(new List<string>
                {
                    " Id Must Than Zero "
                });
            }

            var salary = await _repository.GetSalaryByIdAsync(id);
            if (salary == null)
            {
                throw new NotFoundException("Data not found");
            }
            return _mapper.Map<SalaryResDto>(salary);
        }

        public async Task<SalaryResDto> CreateSalaryAsync(SalaryReqDto salary)
        {
           var error = new List<string>();

            if (salary == null)
            {
                throw new BadRequestException("BadRequest Data ");
            }
            var newdata = _mapper.Map<Salary>(salary);
            if (string.IsNullOrEmpty(newdata.createby)) 
            {
                newdata.createby = "System"; // Provide a default if missing
            }
            if (newdata.createdate == default(DateTime))
            {
                newdata.createdate = DateTime.Now;
            }
            var result = await _repository.CreateSalaryAsync(newdata);
            return _mapper.Map<SalaryResDto>(result);
        }

        public async Task<SalaryResDto> UpdateSalaryAsync(int id, SalaryReqDto salary)
        {
            var entity = await _repository.GetSalaryByIdAsync(id);
            if (entity == null)
            {
                throw new NotFoundException("Data not found");
            }

            var error = new List<string>();
            if(salary == null)
            {
                throw new BadRequestException("BadRequest Data");
            }

            var originalCreateBy = entity.createby;
            var originalCreateDate = entity.createdate;

            _mapper.Map(salary, entity);
            
            if (string.IsNullOrEmpty(entity.createby))
            {
                entity.createby = originalCreateBy;
            }
            if (entity.createdate == default(DateTime))
            {
                entity.createdate = originalCreateDate;
            }

            entity.Id = id;
            var result = await _repository.UpdateSalaryAsync(entity);
            return _mapper.Map<SalaryResDto>(result);

        }

        public async Task<bool> DeleteSalaryAsync(int id)
        {
            var entity = await _repository.GetSalaryByIdAsync(id);
            if (entity == null)
            {
                throw new NotFoundException("Data NotFound");
            }
            await _repository.DeleteSalaryAsync(entity);
            return true;
        }

        
    }
}
