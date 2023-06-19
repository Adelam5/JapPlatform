using JapPlatformBackend.Common.Response;
using JapPlatformBackend.Core.Dtos.Program;

namespace JapPlatformBackend.Core.Interfaces
{
    public interface IProgramService
    {
        Task<ServiceResponse<GetProgramDto>> GetById(int id);
        Task<ServiceResponse<List<GetProgramDto>>> List();
        Task<ServiceResponse<GetProgramDto>> Create(CreateProgramDto newProgram);
        Task<ServiceResponse<GetProgramDto>> Update(int id, UpdateProgramDto updatedProgram);
        Task<ServiceResponse<List<GetProgramDto>>> Delete(int id);
        Task<ServiceResponse<GetProgramDto>> AddItem(int programId, AddItemPrograms itemProgram);
        Task<ServiceResponse<GetProgramDto>> RemoveItem(int programId, int ItemId);
    }
}
