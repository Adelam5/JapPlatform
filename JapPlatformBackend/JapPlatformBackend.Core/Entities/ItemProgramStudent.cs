using JapPlatformBackend.Common.Enums;

namespace JapPlatformBackend.Core.Entities
{
    public class ItemProgramStudent
    {
        public int ItemProgramId { get; set; }
        public ItemProgram ItemProgram { get; set; }
        public int? StudentId { get; set; }
        public Student? Student { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double Progress { get; set; } = 0;
        public ProgressStatus ProgressStatus { get; set; } = ProgressStatus.NotStarted;
    }
}
