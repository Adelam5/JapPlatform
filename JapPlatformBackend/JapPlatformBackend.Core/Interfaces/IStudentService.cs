using JapPlatformBackend.Common.Response;
using JapPlatformBackend.Core.Dtos.Comment;
using JapPlatformBackend.Core.Dtos.Student;

namespace JapPlatformBackend.Core.Interfaces
{
    public interface IStudentService
    {
        Task<PagedResponse<List<GetStudentDto>>> List(StudentSearchDto search);
        Task<ServiceResponse<GetStudentDto>> GetById(int id);
        Task<ServiceResponse<GetStudentProfileDto>> GetProfile();
        Task<ServiceResponse<GetStudentDto>> Create(CreateStudentDto newStudent);
        Task<ServiceResponse<GetStudentDto>> Update(int id, UpdateStudentDto updatedStudent);
        Task<ServiceResponse<List<GetStudentDto>>> Delete(int id);
        Task<ServiceResponse<GetStudentDto>> AddComment(CreateCommentDto newComment);
    }
}
