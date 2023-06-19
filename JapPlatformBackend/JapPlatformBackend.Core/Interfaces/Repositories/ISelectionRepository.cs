using JapPlatformBackend.Core.Dtos.Selection;
using JapPlatformBackend.Core.Entities;

namespace JapPlatformBackend.Core.Interfaces.Repositories
{
    public interface ISelectionRepository : IBaseRepository<Selection, CreateSelectionDto,
        UpdateSelectionDto, GetSelectionDto>
    {
        Task<GetSelectionDto> AddStudent(int studentId, int slectionId);
        Task<GetSelectionDto> RemoveStudent(int studentId, int slectionId);
    }
}
