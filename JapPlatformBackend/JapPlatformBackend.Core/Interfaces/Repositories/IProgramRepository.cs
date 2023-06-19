using JapPlatformBackend.Core.Dtos.Program;
using JapPlatformBackend.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JapPlatformBackend.Core.Interfaces.Repositories
{
    public interface IProgramRepository : IBaseRepository<Program, CreateProgramDto, UpdateProgramDto, GetProgramDto>
    {
        Task<GetProgramDto> AddItem(int programId, AddItemPrograms itemProgram);

        Task<GetProgramDto> RemoveItem(int programId, [FromBody] int itemId);
    }
}
