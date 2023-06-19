using FluentValidation;
using FluentValidation.Results;
using JapPlatformBackend.Api.Exceptions;
using JapPlatformBackend.Core.Dtos.Comment;
using JapPlatformBackend.Core.Dtos.Student;
using JapPlatformBackend.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JapPlatformBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult>
            List([FromQuery] StudentSearchDto search)
        {
            return Ok(await studentService.List(search));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await studentService.GetById(id));
        }

        [Authorize(Roles = "Student")]
        [HttpGet("Profile")]
        public async Task<ActionResult> GetProfile()
        {
            return Ok(await studentService.GetProfile());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Create(CreateStudentDto newStudent, [FromServices] IValidator<CreateStudentDto> validator)
        {
            ValidationResult validationResult = validator.Validate(newStudent);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException(validationResult.Errors[0].ErrorMessage);
            }

            return Ok(await studentService.Create(newStudent));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateStudentDto updatedStudent, [FromServices] IValidator<UpdateStudentDto> validator)
        {
            ValidationResult validationResult = validator.Validate(updatedStudent);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException(validationResult.Errors[0].ErrorMessage);
            }

            return Ok(await studentService.Update(id, updatedStudent));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await studentService.Delete(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("AddComment")]
        public async Task<ActionResult> AddComment(CreateCommentDto newComment)
        {
            return Ok(await studentService.AddComment(newComment));
        }
    }
}