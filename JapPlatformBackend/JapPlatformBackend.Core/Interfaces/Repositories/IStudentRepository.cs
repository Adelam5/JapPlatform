using JapPlatformBackend.Core.Dtos.Comment;
using JapPlatformBackend.Core.Dtos.Student;
using JapPlatformBackend.Core.Entities;

namespace JapPlatformBackend.Core.Interfaces.Repositories
{
    public interface IStudentRepository : IBaseRepository<Student, CreateStudentDto,
        UpdateStudentDto, GetStudentDto>
    {
        Task<GetStudentDto> AddComment(int authorId, CreateCommentDto newComment);
    }
}
