using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Exceptions;
using APARTMENT_API.Helpers;
using APARTMENT_API.Model;
using APARTMENT_API.Repositories;
using APARTMENT_API.Repositories.Interfaces;
using APARTMENT_API.Services.Interfaces;
using AutoMapper;

namespace APARTMENT_API.Services
{
    public class ItemService : IItemService
    {
        public readonly IItemRepository _itemRepository;
        public readonly IMapper _mapper;
        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ItemResDto>> GetItemAsync(int page = 1, int pageSize = 10)
        {
            var items = await _itemRepository.GetItemAsync(page, pageSize);
            if (items == null)
            {
                throw new NotFoundException("Data not found.");
            }
            return new PagedResult<ItemResDto>
            {
                PageNumber = items.PageNumber,
                PageSize = items.PageSize,
                TotalRecords = items.TotalRecords,
                TotalPages = items.TotalPages,
                Data = _mapper.Map<List<ItemResDto>>(items.Data),
            };
        }

        public async Task<List<ItemResDto>> GetAllItemAsync()
        {
            var items = await _itemRepository.GetAllItemAsync();
            return _mapper.Map<List<ItemResDto>>(items);
        }

        public async Task<ItemResDto> GetItemByIdAsync(int itemId)
        {
            var item = await _itemRepository.GetItemByIdAsync(itemId);
            return _mapper.Map<ItemResDto>(item);
        }

        public async Task<ItemResDto> CreateItemAsync(ItemReqDto item)
        {
            if (item == null)
            {
                throw new BadRequestException("Bad Request.");
            }
            var newItem = _mapper.Map<ItemReqDto,Item>(item);
            var createdItem = await _itemRepository.CreateItemAsync(newItem);
            return _mapper.Map<ItemResDto>(createdItem);
        }

        public async Task<ItemResDto> UpdateItemAsync(int itemId, ItemReqDto item)
        {
            if (item == null)
            {
                throw new BadRequestException("Bad Request.");
            }

            var existingItem = await _itemRepository.GetItemByIdAsync(itemId);

            if (existingItem == null)
            {
                throw new NotFoundException("Item not found.");
            }
            _mapper.Map(item, existingItem);
            var updatedItem = await _itemRepository.UpdateItemAsync(existingItem);
            return _mapper.Map<ItemResDto>(updatedItem);
        }

        public async Task<bool> Delete(int itemId)
        {
            var existingItem = await _itemRepository.GetItemByIdAsync(itemId);
            if (existingItem == null)
            {
                throw new NotFoundException("Item not found.");
            }
            return await _itemRepository.DeleteItemAsync(existingItem);
        }
    }
}
