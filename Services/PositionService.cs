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
    public class PositionService : IPositionService
    {

        private readonly IPositionRepository _repository;
        private readonly IMapper _mapper;
        public PositionService(IPositionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        

        public async Task<PagedResult<PositionResDto>> GetPositionAsync(int page = 1, int pagesize = 10)
        {
            var position = await _repository.GetPositionAsync(page, pagesize);
            if (position == null)
            {
                throw new NotFoundException("Data Not Found");
            }
            return new PagedResult<PositionResDto>
            {
                PageNumber = page,
                PageSize = pagesize,
                TotalPages = position.TotalPages,
                TotalRecords = position.TotalRecords,
                Data = _mapper.Map<List<PositionResDto>>(position.Data)
            };
        }

        public async Task<List<PositionResDto>> GetAllPositionAsync()
        {
            var expensType = await _repository.GetAllPositionAsync();
            if (expensType == null)
            {
                throw new NotFoundException("Data Not Found");
            }
            return _mapper.Map<List<PositionResDto>>(expensType);
        }

        public async Task<PositionResDto> GetPositionByIdAsync(int id)
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

            var expensType = await _repository.GetPositionByIdAsync(id);

            if (expensType == null)
            {
                throw new NotFoundException("Data not found.");
            }

            return _mapper.Map<Position, PositionResDto>(expensType);
        }
        public async Task<PositionResDto> CreatePositionAsync(PositionResDto positionResDto)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(positionResDto.positionName))
            {
                errors.Add("ExpensType is required.");
            }

            if (string.IsNullOrEmpty(positionResDto.positionNameKh))
            {
                errors.Add("ExpensType is required.");
            }

            if (errors.Count > 0)
            {
                throw new ValidationException(errors);
            }
            var data = _mapper.Map<Position>(positionResDto);
            var expensType = await _repository.CreatePositionAsync(data);

            return _mapper.Map<Position, PositionResDto>(expensType);


            
        }

        public async Task<bool> DeletePositionAsync(int id)
        {
            var entity = await _repository.GetPositionByIdAsync(id);
            if (entity == null)
                throw new NotFoundException("Not found.");
            await _repository.DeletePositionAsync(entity);
            return true;
        }


        public async Task<PositionResDto> UpdatePositionAsync(int id, PositionResDto positionResDto)
        {

            var entity = await _repository.GetPositionByIdAsync(id);
            if (entity == null)
                throw new NotFoundException("Not found.");

            var errors = new List<string>();

            // កែសារ Error ឲ្យត្រូវនឹងបរិបទ Position
            if (string.IsNullOrEmpty(positionResDto.positionName))
            {
                errors.Add("Position Name is required.");
            }

            if (string.IsNullOrEmpty(positionResDto.positionNameKh))
            {
                errors.Add("Position Name (Khmer) is required.");
            }

            if (errors.Count > 0)
            {
                throw new ValidationException(errors);
            }

            // ដំណោះស្រាយការពារ Error ដូរ Primary Key (Id)
            // កំណត់តម្លៃម្ដងមួយៗ ដោយមិនប៉ះពាល់ដល់ entity.Id ឡើយ
            entity.positionName = positionResDto.positionName;
            entity.positionNameKh = positionResDto.positionNameKh;
            entity.status = positionResDto.status;

            try
            {
                var updatedPosition = await _repository.UpdatePositionAsync(entity);
                return _mapper.Map<Position, PositionResDto>(updatedPosition);
            }
            catch (Exception ex)
            {
                var realDbError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                throw new Exception($"កំហុសពី DB ពេល Update គឺ៖ {realDbError}");
            }
        }


        
    }
}
