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
    public class ExpensTypeService : IExpensTypeService
    {
        private readonly IExpensTypeRepository _repository;
        private readonly IMapper _mapper;
        public ExpensTypeService(IExpensTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedResult<ExpensTypeResDto>> GetExpensTypeAsync(int page = 1, int pagesize = 10)
        {
            var expnensType = await _repository.GetExpensTypeAsync(page, pagesize);
            if (expnensType == null)
            {
                throw new NotFoundException("Data Not Found");
            }
            return new PagedResult<ExpensTypeResDto>
            {
                PageNumber = page,
                PageSize = pagesize,
                TotalPages = expnensType.TotalPages,
                TotalRecords = expnensType.TotalRecords,
                Data = _mapper.Map<List<ExpensTypeResDto>>(expnensType.Data)
            };
        }

        public async Task<List<ExpensTypeResDto>> GetAllExpensTypeAsync()
        {
            var expensType = await _repository.GetAllExpensTypeAsync();
            if (expensType == null)
            {
                throw new NotFoundException("Data Not Found");
            }
            return _mapper.Map<List<ExpensTypeResDto>>(expensType);
        }



        public async Task<ExpensTypeResDto> GetExpensTypeByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ValidationException(
                    new List<string>
                    {
                        "Id must greater than Zero."
                    }
                );
            }

            var expensType = await _repository.GetExpensTypeByIdAsync(id);

            if (expensType == null)
            {
                throw new NotFoundException("Data not found.");
            }

            return _mapper.Map<ExpensType, ExpensTypeResDto>(expensType);
        }
        

        public async Task<ExpensTypeResDto> CreateExpensTypeAsync(ExpensTypeResDto expensTypeResDto)
        {
            var errors = new List<string>();

            // កែសារ Error ឲ្យត្រូវនឹងបរិបទ ExpensType
            if (string.IsNullOrEmpty(expensTypeResDto.expensType))
                errors.Add("ExpensType is required.");

            if (errors.Count > 0)
                throw new ValidationException(errors);

            var data = _mapper.Map<ExpensType>(expensTypeResDto);

            data.Id = 0;

            try
            {
                var createdExpensType = await _repository.CreateExpensTypeAsync(data);

                return _mapper.Map<ExpensType, ExpensTypeResDto>(createdExpensType);
            }
            catch (Exception ex)
            {
                var realDbError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                throw new Exception($"កំហុសចេញពី Database ពិតប្រាកដគឺ៖ {realDbError}");
            }
        }

        public async Task<bool> DeleteExpensTypeAsync(int id)
        {
            var entity = await _repository.GetExpensTypeByIdAsync(id);
            if (entity == null)
                throw new NotFoundException("Not found.");
            await _repository.DeleteAsync(entity);
            return true;
        }



        public async Task<ExpensTypeResDto> UpdateExpensTypeAsync(int id, ExpensTypeResDto expensTypeResDto)
        {

            var entity = await _repository.GetExpensTypeByIdAsync(id);
            if (entity == null)
                throw new NotFoundException("Not found.");

            var errors = new List<string>();

            if (string.IsNullOrEmpty(expensTypeResDto.expensType))
            {
                errors.Add("ExpensType is required.");
            }

            if (errors.Count > 0)
            {
                throw new ValidationException(errors);
            }

            entity.expensType = expensTypeResDto.expensType;

            var expens = await _repository.UpdateExpensTypeAsync(entity);
            return _mapper.Map<ExpensType, ExpensTypeResDto>(expens);


        }

    }
}
