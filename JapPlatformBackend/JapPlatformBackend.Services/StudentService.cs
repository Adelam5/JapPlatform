using AutoMapper;
using JapPlatformBackend.Api.Exceptions;
using JapPlatformBackend.Common;
using JapPlatformBackend.Common.Response;
using JapPlatformBackend.Core.Dtos.Comment;
using JapPlatformBackend.Core.Dtos.Student;
using JapPlatformBackend.Core.Entities;
using JapPlatformBackend.Core.Interfaces;
using JapPlatformBackend.Core.Interfaces.Repositories;
using JapPlatformBackend.Database;
using JapPlatformBackend.Repositories.Helpers;
using JapPlatformBackend.Services.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace JapPlatformBackend.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMailService mailService;
        private readonly IMapper mapper;
        private readonly DataContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<User> userManager;

        public StudentService(IStudentRepository studentRepository, IMailService mailService, IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            this.studentRepository = studentRepository;
            this.mailService = mailService;
            this.mapper = mapper;
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public async Task<ServiceResponse<GetStudentDto>> Create(CreateStudentDto newStudent)
        {

            var userExists = await context.Users
                .AnyAsync(user => user.UserName == newStudent.UserName.ToLower().Trim());

            if (userExists)
                throw new UserAlreadyExistsException();

            var selectionExists = await context.Selections
              .AnyAsync(s => s.Id == newStudent.SelectionId);

            if (!selectionExists)
                newStudent.SelectionId = null;

            var student = mapper.Map<Student>(newStudent);

            student.UserName = newStudent.UserName.ToLower().Trim();

            var result = await userManager.CreateAsync(student, newStudent.Password);

            if (!result.Succeeded)
                throw new BadRequestException(result.Errors.First().Description);

            await userManager.AddToRoleAsync(student, "Student");

            var template = EmailHelpers.CreateTemplateCredentials(student.UserName, newStudent.Password);
            var emailSent = await mailService.SendEmail(student.Email, EmailHelpers.SubjectCredentials, template);

            if (!emailSent)
            {
                throw new JapPlatformException("Student created, email was not sent");
            }

            var students = await Calc.PrepareStudent(context, student.Id);

            var ips = Calc.SetItemsStartEndDates(students);

            context.ItemProgramStudents.AddRange(ips);

            await context.SaveChangesAsync();

            var response = new ServiceResponse<GetStudentDto>
            {
                Data = mapper.Map<GetStudentDto>(student)
            };

            return response;
        }

        public async Task<ServiceResponse<List<GetStudentDto>>> Delete(int id)
        {
            var includes = "Comments";

            var response = new ServiceResponse<List<GetStudentDto>>
            {
                Data = await studentRepository.Delete(id, includes)
            };
            return response;
        }

        public async Task<ServiceResponse<GetStudentDto>> GetById(int id)
        {
            var includes = "Comments.Author, Selection.Program, ItemProgramStudents.ItemProgram.Item";

            var response = new ServiceResponse<GetStudentDto>
            {
                Data = await studentRepository.GetById(id, includes)
            };
            return response;
        }

        public async Task<ServiceResponse<GetStudentProfileDto>> GetProfile()
        {
            int studentId = UserHelpers.GetLoggedInUserId(httpContextAccessor);

            var includes = "Comments.Author, Selection.Program, ItemProgramStudents.ItemProgram.Item";

            var student = await studentRepository.GetById(studentId, includes);

            var response = new ServiceResponse<GetStudentProfileDto>
            {
                Data = mapper.Map<GetStudentProfileDto>(student)
            };
            return response;
        }

        public async Task<PagedResponse<List<GetStudentDto>>> List(StudentSearchDto search)
        {
            var newSearch = mapper.Map<BaseSearch>(search);
            newSearch.Includes = "Selection.Program";

            return await studentRepository.List(newSearch);
        }

        public async Task<ServiceResponse<GetStudentDto>> Update(int id, UpdateStudentDto updatedStudent)
        {
            var response = new ServiceResponse<GetStudentDto>
            {
                Data = await studentRepository.Update(id, updatedStudent)
            };
            return response;
        }

        public async Task<ServiceResponse<GetStudentDto>> AddComment(CreateCommentDto newComment)
        {
            var authorId = UserHelpers.GetLoggedInUserId(httpContextAccessor);

            var response = new ServiceResponse<GetStudentDto>
            {
                Data = await studentRepository.AddComment(authorId, newComment)
            };
            return response;
        }

    }
}