using JapPlatformBackend.Common.Enums;
using JapPlatformBackend.Core.Dtos.ItemProgramStudents;
using JapPlatformBackend.Core.Dtos.Selection;

namespace JapPlatformBackend.Core.Dtos.Student
{
    public class GetStudentProfileDto
    {
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public StudentStatus Status { get; set; }
        public GetReductedSelectionDto? Selection { get; set; }
        public List<ItemProgramStudentDto> PersonalProgram { get; set; } = new();
    }
}
