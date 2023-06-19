using JapPlatformBackend.Core.Dtos.Program;
using JapPlatformBackend.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JapPlatformBackend.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramsController : ControllerBase
    {
        private readonly IProgramService programService;

        public ProgramsController(IProgramService programService)
        {
            this.programService = programService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await programService.GetById(id));
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            return Ok(await programService.List());
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateProgramDto newProgram)
        {
            return Ok(await programService.Create(newProgram));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateProgramDto updatedProgram)
        {
            return Ok(await programService.Update(id, updatedProgram));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await programService.Delete(id));
        }

        [HttpPut("{id}/AddItem")]
        public async Task<ActionResult> AddItem(int id, AddItemPrograms itemProgram)
        {
            return Ok(await programService.AddItem(id, itemProgram));
        }

        [HttpPut("{id}/RemoveItem")]
        public async Task<ActionResult> RemoveItem(int id, int itemId)
        {
            return Ok(await programService.RemoveItem(id, itemId));
        }
    }
}
