using JapPlatformBackend.Common.Enums;

namespace JapPlatformBackend.Core.Dtos.Selection
{
    public class CreateSelectionDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SelectionStatus Status { get; set; }
        public int ProgramId { get; set; }
        public int StudentId { get; set; }
    }
}
