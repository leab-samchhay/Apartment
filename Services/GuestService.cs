using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Exceptions;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories.Interfaces;
using APARTMENT_API.Services.Interfaces;
using AutoMapper;
using Newtonsoft.Json.Schema;

namespace APARTMENT_API.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _repository;
        private readonly IMapper _mapper;
        public GuestService(IGuestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedResult<GuestResDto>> GetGuestPageAsync(int page = 1, int pageSize = 10)
        {
            var guest = await _repository.GetGuestPageAsync(page, pageSize);
            if (guest == null)
            {
                throw new NotFoundException("Data Notfound");
            }
            return new PagedResult<GuestResDto>
            {
                PageNumber = guest.PageNumber,
                PageSize = guest.PageSize,
                TotalPages = guest.TotalPages,
                TotalRecords = guest.TotalRecords,
                Data = _mapper.Map<List<GuestResDto>>(guest.Data)
            };
        }

        public async Task<GuestResDto> GetGuestByIdAsync(int guestId)
        {
            var data = await _repository.GetGuestByIdAsync(guestId);
            return _mapper.Map<GuestResDto>(data);
        }

        public async Task<List<GuestResDto>> GetGuestListAsync()
        {
            var data = await _repository.GetGuestAllAsync();
            return _mapper.Map<List<GuestResDto>>(data);
        }
        public async Task<GuestResDto> CreateGuesAsync(GuestReqDto req)
        {
            if (req == null)
            {
                throw new BadRequestException("Bad Request");
            }
            if(req.ImagePath == null || req.ImagePath.Length == 0)
            {
                throw new BadRequestException("place select an image");
            }
            var allowExtensions = new[]
            {
                ".jpg",
                ".jpeg",
                ".png",
                ".webp"
            };

            var extension = Path.GetExtension(req.ImagePath.FileName).ToLowerInvariant();

            if (!allowExtensions.Contains(extension))
            {
                throw new BadRequestException("Only JPG, JPEG, PNG, and WEBP files are allowed.");

            }

            const long maxFileSize = 5 * 1024 * 1024;

            if(req.ImagePath.Length > maxFileSize)
            {
                throw new BadRequestException("Image size cannot exced 5MB");
            }

            //ការបង្កើតឈ្មោះឯកសារ និង folder សម្រាប់រក្សាទុក

            //unique identifier  បើ user ២នាក់ upload ឯកសារឈ្មោះដូចគ្នា photo.png នឹងសរសេរជាន់គ្នា
            var fileName = $"{Guid.NewGuid()}{extension}";  
            var imagePath = Path.Combine("uploads", "images-guest");

            var uploadsFolder = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot",
                imagePath
            );

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, fileName);

            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await req.ImagePath.CopyToAsync(stream);
            }

            var newData = _mapper.Map<GuestReqDto,Guest>(req);
            newData.ImagePath = Path.Combine(imagePath, fileName);
            var result = await _repository.CreateGuestAsync(newData);
            return _mapper.Map<Guest,GuestResDto>(result);
        }

        
        public async Task<GuestResDto> UpdateGuesAsync(int id, GuestReqDto req)
        {
            if (req == null)
            {
                throw new BadRequestException("Bad Request");
            }

            var existingGuest = await _repository.GetGuestByIdAsync(id);
            if (existingGuest == null)
            {
                throw new NotFoundException("Guest Not Found");
            }

            var oldImagePath = existingGuest.ImagePath;
            _mapper.Map(req, existingGuest);

            if(req.ImagePath is not null &&  req.ImagePath.Length > 0)
            {
                var allowedExtensions = new[]
                {
                    ".jpg",
                    ".jpeg",
                    ".png",
                    ".webp"
                };

                var extension = Path.GetExtension(req.ImagePath.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(extension))
                {
                    throw new BadRequestException(
                        "Only JPG, JPEG, and WEBP file ar allowed."
                    );
                }

                const long maxFileSize = 5 * 1024 * 1024;
                if (req.ImagePath.Length > maxFileSize)
                {
                    throw new BadRequestException(
                        "Image size cannot exceed 5MB."
                    );
                }

                var imagePath = Path.Combine("uploads", "Images-guest");
                var uploadsFolder = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    imagePath
                );

                Directory.CreateDirectory(uploadsFolder);
                var fileName = $"{Guid.NewGuid()}{extension}";

                var newFilePath = Path.Combine(uploadsFolder, fileName);

                await using (var stream = new FileStream(newFilePath, FileMode.Create))
                {
                    await req.ImagePath.CopyToAsync(stream);
                }

                existingGuest.ImagePath = Path.Combine(imagePath, fileName);
            }
            else
            {
                existingGuest.ImagePath = oldImagePath;
            }

            var result = await _repository.UpdateGuestAsync(existingGuest);
            return _mapper.Map<Guest, GuestResDto>(result);

            
        }
        public async Task<bool> DeleteGuestAsync(int guestId)
        {
            var entity = await _repository.GetGuestByIdAsync(guestId);
            if (entity == null)
            {
                throw new NotFoundException("Not found");
            }
            await _repository.DeleteGuestAsync(entity);
            return true;
        }



    }
}
