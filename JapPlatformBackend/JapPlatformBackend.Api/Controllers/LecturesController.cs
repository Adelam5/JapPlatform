using JapPlatformBackend.Core.Dtos.Item;
using JapPlatformBackend.Core.Dtos.Lecture;
using JapPlatformBackend.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JapPlatformBackend.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class LecturesController : ControllerBase
    {
        private readonly ILectureService lectureService;
        public LecturesController(ILectureService lectureService)
        {
            this.lectureService = lectureService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await lectureService.GetById(id));
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery] ItemSearchDto search)
        {
            return Ok(await lectureService.List(search));
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateLectureDto newLecture)
        {
            return Ok(await lectureService.Create(newLecture));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateLectureDto updatedLecture)
        {
            return Ok(await lectureService.Update(id, updatedLecture));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await lectureService.Delete(id));
        }
    }
}
