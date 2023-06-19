using AutoMapper;
using JapPlatformBackend.Api.Exceptions;
using JapPlatformBackend.Core.Dtos.Comment;
using JapPlatformBackend.Core.Dtos.Student;
using JapPlatformBackend.Core.Entities;
using JapPlatformBackend.Core.Interfaces.Repositories;
using JapPlatformBackend.Database;
using JapPlatformBackend.Repositories.Helpers;
using Microsoft.EntityFrameworkCore;

namespace JapPlatformBackend.Repositories
{
    public class StudentRepository : BaseRepository<Student, CreateStudentDto, UpdateStudentDto, GetStudentDto>, IStudentRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public StudentRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public override async Task<GetStudentDto> GetById(int id, string includes)
        {
            var student = await context.Students
                .Include(s => s.Comments)
                    .ThenInclude(c => c.Author)
                .Include(s => s.Selection)
                    .ThenInclude(s => s.Program)
                .Include(s => s.ItemProgramStudents.OrderBy(ips => ips.ItemProgram.OrderNumber))
                    .ThenInclude(ips => ips.ItemProgram)
                        .ThenInclude(ip => ip.Item)
                .FirstOrDefaultAsync(s => s.Id == id);

            return mapper.Map<GetStudentDto>(student);
        }

        public override async Task<GetStudentDto> Update(int id, UpdateStudentDto updatedStudent)
        {
            var student = await context.Students
               .FirstOrDefaultAsync(s => s.Id == id)
               ?? throw new ResourceNotFound("Student");

            var selectionExists = await context.Selections
                .AnyAsync(s => s.Id == updatedStudent.SelectionId);

            if (!selectionExists)
                updatedStudent.SelectionId = student.SelectionId;

            student = mapper.Map(updatedStudent, student);

            student.ModifiedAt = DateTime.Now;

            var students = await Calc.PrepareStudent(context, id);

            var ips = Calc.SetItemsStartEndDates(students);

            context.ItemProgramStudents.AddRange(ips);

            await context.SaveChangesAsync();

            return mapper.Map<GetStudentDto>(student);
        }

        public async Task<GetStudentDto> AddComment(int authorId, CreateCommentDto newComment)
        {
            var student = await context.Students
                .Include(s => s.Comments)
                    .ThenInclude(c => c.Author)
                .FirstOrDefaultAsync(s => s.Id == newComment.StudentId)
                ?? throw new ResourceNotFound("Student");
            var comment = mapper.Map<Comment>(newComment);

            comment.AuthorId = authorId;

            context.Comments.Add(comment);
            await context.SaveChangesAsync();

            return mapper.Map<GetStudentDto>(student);
        }
    }
}
