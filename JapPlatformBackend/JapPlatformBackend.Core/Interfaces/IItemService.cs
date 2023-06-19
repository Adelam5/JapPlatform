using JapPlatformBackend.Common.Response;
using JapPlatformBackend.Core.Dtos.Item;

namespace JapPlatformBackend.Core.Interfaces
{
    public interface IItemService
    {
        Task<List<GetItemDto>> List();
        Task<ServiceResponse<List<GetItemDto>>> GetEventsByProgram(int programId);
        Task<ServiceResponse<GetItemDto>> Create(CreateItemDto newLecture);
        Task<ServiceResponse<bool>> CreateEventAndAddToProgram(CreateEventDto newEvent);
        Task<ServiceResponse<List<GetItemDto>>> Delete(int id);
    }
}
