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
    public class OrtherExpenseService : IOrtherExpenseService
    {

        private readonly IOrtherExpnseRepository _repository;
        private readonly IMapper _mapper;
        public OrtherExpenseService(IOrtherExpnseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResult<OrtherExpenseResDto>> GetOrtherExpenseAsync(int page = 1, int paseSize = 10)
        {
           var OrtherExpense = await _repository.GetOrherAsync(page, paseSize);
            if (OrtherExpense == null)
            {
                throw new NotFoundException("Data Not Found");
            }
            return new PagedResult<OrtherExpenseResDto>
            {
                PageNumber = OrtherExpense.PageNumber,
                PageSize = OrtherExpense.PageSize,
                TotalPages = OrtherExpense.TotalPages,
                TotalRecords = OrtherExpense.TotalRecords,
                Data = _mapper.Map<List<OrtherExpenseResDto>>(OrtherExpense.Data)
            };
        }
        public async Task<List<OrtherExpenseResDto>> GetAllOrtherExpenseAsync()
        {
            var data = await _repository.GetAllOrtherAsync();
            return _mapper.Map<List<OrtherExpenseResDto>>(data);
        }

        public async Task<OrtherExpenseResDto> GetOrtherExpenseByIdAsync(int id)
        {
            var data = await _repository.GetOrtherByAnsync(id);
            return _mapper.Map<OrtherExpenseResDto>(data);
        }
        public async Task<OrtherExpenseResDto> CreateOrtherExpenseAsync(OrtherExpenseResDto ortherExpense)
        {
            if(ortherExpense == null)
            {
                throw new BadRequestException("Bad Request");
            }
            var newData = _mapper.Map<OrtherExpenseResDto, OrtherExpense>(ortherExpense);
            var result = await _repository.CreateOrtherAsnync(newData);
            return _mapper.Map<OrtherExpense, OrtherExpenseResDto>(result);
        }
   

        public async Task<OrtherExpenseResDto> UpdateOrtherExpenseAsync(int id, OrtherExpenseResDto ortherExpenseResDto)
        {
            if(ortherExpenseResDto == null)
            {
                throw new BadRequestException("Bad Request ");
            }

            var entity = await _repository.GetOrtherByAnsync(id);

            if(entity == null)
            {
                throw new NotFoundException("Data Not Found");
            }
            _mapper.Map(ortherExpenseResDto, entity);
            entity.Id = id;
            var resul = await _repository.UpdateOrtherAsync(entity);
            return _mapper.Map<OrtherExpense, OrtherExpenseResDto>(resul);
        }
        public async Task<bool> DeleteOrtherExpensAsync(int id)
        {
            var entity = await _repository.GetOrtherByAnsync(id);
            if (entity == null)
            {
                throw new NotFoundException($"{nameof(id)} does not exist");

            }
            await _repository.DeleteOrtherAsync(entity);
            return true;
        }
    }
}
