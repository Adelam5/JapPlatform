using JapPlatformBackend.Core.Dtos.Item;
using JapPlatformBackend.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JapPlatformBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService itemService;

        public ItemsController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            return Ok(await itemService.List());
        }

        [HttpGet("Events/{programId}")]
        public async Task<ActionResult> GetEventsByProgram(int programId)
        {
            return Ok(await itemService.GetEventsByProgram(programId));
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateItemDto newLecture)
        {
            return Ok(await itemService.Create(newLecture));
        }

        [HttpPost("Events/New")]
        public async Task<ActionResult> CreateEventAndAddToProgram(CreateEventDto newEvent)
        {
            return Ok(await itemService.CreateEventAndAddToProgram(newEvent));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await itemService.Delete(id));
        }
    }
}
