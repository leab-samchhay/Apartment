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
    public class FloorsService:IFloorsService  
    {
        private readonly IFloorsRepository _repository;
        private readonly IMapper _mapper;
        public FloorsService (IFloorsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedResult<FloorsResDto>> GetFloorsAsync(int page = 1, int pageSize = 10)
        {
            var Floors = await _repository.GetFloorsAsync(page, pageSize);
            if (Floors == null)
            {
                throw new NotFoundException("Data not found.");
            }
            return new PagedResult<FloorsResDto>
            {
                PageNumber = Floors.PageNumber,
                PageSize = Floors.PageSize,
                TotalRecords = Floors.TotalRecords,
                TotalPages = Floors.TotalPages,
                Data = _mapper.Map<List<FloorsResDto>>(Floors.Data),
            };
        }

        public async Task<List<FloorsResDto>> GetFloorsAllAsync()
        {
            var data = await _repository.GetFloorsAllAsync();
            return _mapper.Map<List<FloorsResDto>>(data);
        }

        public async Task<FloorsResDto> GetFloorByIdAsync(int floorsId)
        {
            var data = await _repository.GetFloorsByIdAsync(floorsId);
            return _mapper.Map<FloorsResDto>(data);
        }

        public async Task<FloorsResDto> CreateAsync(FloorsReqDto req)
        {
            if (req == null)
            {
                throw new BadRequestException("Bad Request.");
            }
            var newData = _mapper.Map<FloorsReqDto, Floors>(req);
            var result = await _repository.CreateAsync(newData);
            return _mapper.Map<Floors, FloorsResDto>(result);
        }

        public async Task<FloorsResDto> UpdateAsync(int id, FloorsReqDto req)
        {
            if (req == null)
            {
                throw new BadRequestException("Bad Request.");
            }
            var entity = await _repository.GetFloorsByIdAsync(id);
            if (entity == null)
            {
                throw new NotFoundException("Data not Found.");
            }
            _mapper.Map(req, entity);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<Floors, FloorsResDto>(result);
        }
        public async Task<bool> DeletAsync(int floorId)
        {
            var entity = await _repository.GetFloorsByIdAsync(floorId);
            if (entity == null)
            {
                throw new NotFoundException("Not found");
            }
            await _repository.DeletAsync(entity);
            return true;
        }
    }
}
