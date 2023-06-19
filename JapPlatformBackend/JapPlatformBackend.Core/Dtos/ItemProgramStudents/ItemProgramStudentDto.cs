using JapPlatformBackend.Common.Enums;

namespace JapPlatformBackend.Core.Dtos.ItemProgramStudents
{
    public class ItemProgramStudentDto
    {
        public int OrderNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Discriminator { get; set; }
        public int WorkHours { get; set; }
        public string Urls { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Progress { get; set; } = 0;
        public ProgressStatus ProgressStatus { get; set; } = ProgressStatus.NotStarted;
    }
}
