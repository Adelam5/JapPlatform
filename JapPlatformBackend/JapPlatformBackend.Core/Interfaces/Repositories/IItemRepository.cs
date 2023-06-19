using JapPlatformBackend.Core.Dtos.Item;
using JapPlatformBackend.Core.Entities.Base;

namespace JapPlatformBackend.Core.Interfaces.Repositories
{
    public interface IItemRepository : IBaseRepository<Item, CreateItemDto, UpdateItemDto, GetItemDto>
    {
        Task<List<GetItemDto>> GetEventsByProgram(int programId);
        Task<bool> CreateEventAndAddToProgram(CreateEventDto newEvent);
    }
}
