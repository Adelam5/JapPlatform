using FluentValidation;
using FluentValidation.Results;
using JapPlatformBackend.Api.Exceptions;
using JapPlatformBackend.Core.Dtos.Selection;
using JapPlatformBackend.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace JapPlatformBackend.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SelectionsController : ControllerBase
    {
        private readonly ISelectionService selectionService;

        public SelectionsController(ISelectionService selectionService)
        {
            this.selectionService = selectionService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery] SelectionSearchDto search)
        {
            return Ok(await selectionService.List(search));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await selectionService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateSelectionDto newSelection, [FromServices] IValidator<CreateSelectionDto> validator)
        {
            ValidationResult validationResult = validator.Validate(newSelection);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException(validationResult.Errors[0].ErrorMessage);
            }

            return Ok(await selectionService.Create(newSelection));
        }

        [HttpPut("AddStudent")]
        public async Task<ActionResult> AddStudent(UpdateStudentsListDto ids)
        {
            return Ok(await selectionService.AddStudent(ids.StudentId, ids.SelectionId));
        }

        [HttpPut("RemoveStudent")]
        public async Task<ActionResult> RemoveStudent(UpdateStudentsListDto ids)
        {
            return Ok(await selectionService.RemoveStudent(ids.StudentId, ids.SelectionId));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateSelectionDto updatedSelection, [FromServices] IValidator<UpdateSelectionDto> validator)
        {
            ValidationResult validationResult = validator.Validate(updatedSelection);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException(validationResult.Errors[0].ErrorMessage);
            }

            return Ok(await selectionService.Update(id, updatedSelection));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await selectionService.Delete(id));
        }


    }
}
