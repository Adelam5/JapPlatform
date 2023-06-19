using JapPlatformBackend.Common.Enums;
using JapPlatformBackend.Core.Entities.Base;

namespace JapPlatformBackend.Core.Entities
{
    public class Selection : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SelectionStatus Status { get; set; }

        public int ProgramId { get; set; }
        public Program Program { get; set; }

        public List<Student> Students { get; set; } = new();

    }
}
