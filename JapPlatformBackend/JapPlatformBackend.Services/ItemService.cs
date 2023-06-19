using AutoMapper;
using JapPlatformBackend.Common.Response;
using JapPlatformBackend.Core.Dtos.Item;
using JapPlatformBackend.Core.Interfaces;
using JapPlatformBackend.Core.Interfaces.Repositories;

namespace JapPlatformBackend.Services
{
    public class ItemService : IItemService
    {
        private readonly IMapper mapper;
        private readonly IItemRepository itemRepository;

        public ItemService(IMapper mapper, IItemRepository itemRepository)
        {
            this.mapper = mapper;
            this.itemRepository = itemRepository;
        }

        public async Task<List<GetItemDto>> List()
        {
            return await itemRepository.GetAll();
        }
        public async Task<ServiceResponse<List<GetItemDto>>> GetEventsByProgram(int programId)
        {
            var response = new ServiceResponse<List<GetItemDto>>
            {
                Data = await itemRepository.GetEventsByProgram(programId)
            };
            return response;
        }


        public async Task<ServiceResponse<GetItemDto>> Create(CreateItemDto newLecture)
        {
            var response = new ServiceResponse<GetItemDto>
            {
                Data = await itemRepository.Create(newLecture)
            };
            return response;
        }

        public async Task<ServiceResponse<bool>> CreateEventAndAddToProgram(CreateEventDto newEvent)
        {
            var response = new ServiceResponse<bool>
            {
                Data = await itemRepository.CreateEventAndAddToProgram(newEvent)
            };
            return response;
        }

        public async Task<ServiceResponse<List<GetItemDto>>> Delete(int id)
        {
            var response = new ServiceResponse<List<GetItemDto>>
            {
                Data = await itemRepository.Delete(id)
            };
            return response;
        }
    }
}
