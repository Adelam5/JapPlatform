using JapPlatformBackend.Common.Enums;
using JapPlatformBackend.Core.Dtos.Program;
using JapPlatformBackend.Core.Dtos.Student;

namespace JapPlatformBackend.Core.Dtos.Selection
{
    public class GetSelectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SelectionStatus Status { get; set; }
        public GetProgramDto? Program { get; set; }
        public List<GetStudentDto>? Students { get; set; }
    }
}
