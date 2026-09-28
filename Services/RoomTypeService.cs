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
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomType _repository;
        private readonly IMapper _mapper;

        public RoomTypeService(IRoomType repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResult<RoomTypeResDto>> GetRoomType(int page = 1, int pageSize = 10)
        {
            var roomTypes = await _repository.GetRoomType(page, pageSize);

            return new PagedResult<RoomTypeResDto>
            {
                PageNumber = roomTypes.PageNumber,
                PageSize = roomTypes.PageSize,
                TotalRecords = roomTypes.TotalRecords,
                TotalPages = roomTypes.TotalPages,
                Data = _mapper.Map<List<RoomTypeResDto>>(roomTypes.Data)
            };
        }

        public async Task<List<RoomTypeResDto>> GetAllRoomType()
        {
            var roomTypes = await _repository.GetAllRoomType();

            return _mapper.Map<List<RoomTypeResDto>>(roomTypes);
        }

        public async Task<RoomTypeResDto?> GetRoomTypeById(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException(new List<string>
                {
                    "Id must be greater than zero."
                });
            }

            var roomType = await _repository.GetRoomTypeById(id);

            if (roomType == null)
            {
                throw new NotFoundException("Room Type not found.");
            }

            return _mapper.Map<RoomTypeResDto>(roomType);
        }

        public async Task<RoomTypeResDto> Create(RoomTypeReqDto roomTypeDto)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(roomTypeDto.RoomTypeName))
                errors.Add("RoomTypeName is required.");

            if (string.IsNullOrWhiteSpace(roomTypeDto.RoomTypeNameKh))
                errors.Add("RoomTypeNameKh is required.");

            if (errors.Any())
                throw new ValidationException(errors);

            var entity = _mapper.Map<RoomType>(roomTypeDto);

            var result = await _repository.Create(entity);

            return _mapper.Map<RoomTypeResDto>(result);
        }

        public async Task<RoomTypeResDto> Update(int id, RoomTypeReqDto roomTypeDto)
        {
            if (id <= 0)
            {
                throw new ValidationException(new List<string>
                {
                    "Id must be greater than zero."
                });
            }

            var entity = await _repository.GetRoomTypeById(id);

            if (entity == null)
            {
                throw new NotFoundException("Room Type not found.");
            }

            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(roomTypeDto.RoomTypeName))
                errors.Add("RoomTypeName is required.");

            if (string.IsNullOrWhiteSpace(roomTypeDto.RoomTypeNameKh))
                errors.Add("RoomTypeNameKh is required.");

            if (errors.Any())
                throw new ValidationException(errors);

            _mapper.Map(roomTypeDto, entity);

            var result = await _repository.Update(entity);

            return _mapper.Map<RoomTypeResDto>(result);
        }

        public async Task<bool> Delete(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException(new List<string>
                {
                    "Id must be greater than zero."
                });
            }

            var entity = await _repository.GetRoomTypeById(id);

            if (entity == null)
            {
                throw new NotFoundException("Room Type not found.");
            }

            return await _repository.Delete(entity);
        }
    }
}