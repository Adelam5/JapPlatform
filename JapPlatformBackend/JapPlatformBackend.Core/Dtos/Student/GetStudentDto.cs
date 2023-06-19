using JapPlatformBackend.Common.Enums;
using JapPlatformBackend.Core.Dtos.Comment;
using JapPlatformBackend.Core.Dtos.ItemProgramStudents;
using JapPlatformBackend.Core.Dtos.Program;
using JapPlatformBackend.Core.Dtos.Selection;
using JapPlatformBackend.Core.Dtos.UserRole;

namespace JapPlatformBackend.Core.Dtos.Student
{
    public class GetStudentDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public StudentStatus Status { get; set; }
        public GetSelectionDto? Selection { get; set; }
        public GetProgramDto? Program { get; set; }
        public List<GetCommentDto> Comments { get; set; } = new();
        public ICollection<UserRoleDto> UserRoles { get; set; }
        public List<ItemProgramStudentDto> ItemProgramStudents { get; set; } = new();

    }
}
