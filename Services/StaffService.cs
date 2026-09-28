using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Exceptions;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories.Interfaces;
using APARTMENT_API.Services.Interfaces;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;

namespace APARTMENT_API.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _repository;
        private readonly IMapper _mapper;
        public StaffService (IStaffRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<PagedResult<StaffResDto>> GetStaffAsync(int page = 1, int pageSize = 10)
        {
            var staff = await _repository.GetStaffAsync(page, pageSize);
            if(staff == null)
            {
                throw new NotFoundException("Data Not found ");
            }
            return new PagedResult<StaffResDto>
            {
                PageNumber = staff.PageNumber,
                PageSize = staff.PageSize,
                TotalPages = staff.TotalPages,
                TotalRecords = staff.TotalRecords,
                Data = _mapper.Map<List<StaffResDto>>(staff.Data)
            };
        }
        public async Task<List<StaffResDto>> GetAllStaffAsync()
        {
            var data = await _repository.GetAllStaffListAsync();
            return _mapper.Map<List<StaffResDto>>(data);
        }

        public async Task<StaffResDto> GetStaffByIdAsync(int id)
        {
            var data = await _repository.GetStaffByIdAsync(id);
            return _mapper.Map<StaffResDto>(data);
        }
        public async Task<StaffResDto> CreateStaffAsync(StaffReqDto staffReqDto)
        {
            if(staffReqDto == null)
            {
                throw new BadRequestException("Bad Request");
            }

            if(staffReqDto.photo == null || staffReqDto.photo.Length == 0)
            {
                throw new BadRequestException("place to select an photo");
            }

            var allowEntention = new[]
            {
                ".png",
                ".jpeg",
                ".jpg",
                ".webp"
            };

            var extension = Path.GetExtension(staffReqDto.photo.FileName).ToLower();
            if (!allowEntention.Contains(extension))
            {
                throw new BadRequestException("only JPG, JPEG, PNG, and WEB file are allowed.");
            }

            const long maxFilSeze = 5 * 1024 * 1024;

            if(staffReqDto.photo.Length > maxFilSeze)
            {
                throw new BadRequestException("photo size can't exed 5MB");
            }

            var fileName = $"{Guid.NewGuid()}{extension}";
            var photo = Path.Combine("uploads", "photo-staffe");

            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", photo);

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            var filePath = Path.Combine(uploadFolder, fileName);

            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await staffReqDto.photo.CopyToAsync(stream);
            }


            var newData = _mapper.Map<StaffReqDto, Staff>(staffReqDto);
            newData.photo = Path.Combine(photo, fileName).Replace("\\", "/"); 
            var result = await _repository.CreateStaffAsync(newData);
            return _mapper.Map<Staff, StaffResDto>(result);
        }


        public async Task<StaffResDto> UpdateStaffAsync(int id, StaffReqDto staffReqDto) // តាមពិតគួរប្រើ StaffReqDto
        {
            var entity = await _repository.GetStaffByIdAsync(id);

            if (entity == null)
            {
                throw new NotFoundException("Data NotFound");
            }

            var errors = new List<string>();

            if (staffReqDto.photo == null)
            {
                errors.Add("photo is Required"); 
            }
            if (string.IsNullOrEmpty(staffReqDto.name))
            {
                errors.Add("name is Required");
            }
            if (staffReqDto.dob == null) 
            {
                errors.Add("dob is Required");
            }
            if (string.IsNullOrEmpty(staffReqDto.createBy)) 
            {
                errors.Add("createBy is Required");
            }

            if (errors.Count > 0)
            {
                throw new ValidationException(errors);
            }

            // Note: If you want to update the photo, you will need to upload it similar to CreateStaffAsync
            // and update the photo path string on the entity.
            // For now, mapping directly from req to entity
            _mapper.Map(staffReqDto, entity);

            entity.Id = id;

            var result = await _repository.UpdateStaffAsync(entity);

            return _mapper.Map<StaffResDto>(result);
        }
        public async Task<bool> DeleteStaffAsync(int id)
        {
            var entity = await _repository.GetStaffByIdAsync(id);
            if (entity == null)
            {
                throw new NotFoundException("Data NotFound");
            }
            await _repository.DeleteStaffAsync(entity);
            return true;
        }

    }
}
