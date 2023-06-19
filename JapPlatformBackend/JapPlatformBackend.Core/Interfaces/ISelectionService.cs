using JapPlatformBackend.Common.Response;
using JapPlatformBackend.Core.Dtos.Selection;

namespace JapPlatformBackend.Core.Interfaces
{
    public interface ISelectionService
    {
        Task<PagedResponse<List<GetSelectionDto>>> List(SelectionSearchDto search);
        Task<ServiceResponse<GetSelectionDto>> GetById(int id);
        Task<ServiceResponse<GetSelectionDto>> Create(CreateSelectionDto newSelection);
        Task<ServiceResponse<GetSelectionDto>> Update(int id, UpdateSelectionDto uodatedSelection);
        Task<ServiceResponse<GetSelectionDto>> AddStudent(int slectionId, int studentId);
        Task<ServiceResponse<GetSelectionDto>> RemoveStudent(int slectionId, int studentId);
        Task<ServiceResponse<List<GetSelectionDto>>> Delete(int id);
    }
}
