using JapPlatformBackend.Common.Enums;

namespace JapPlatformBackend.Core.Dtos.Student
{
    public class UpdateStudentDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public StudentStatus Status { get; set; }
        public int? SelectionId { get; set; }
    }
}
