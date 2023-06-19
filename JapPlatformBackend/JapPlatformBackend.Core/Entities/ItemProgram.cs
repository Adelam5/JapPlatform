using JapPlatformBackend.Core.Entities.Base;

namespace JapPlatformBackend.Core.Entities
{
    public class ItemProgram : BaseEntity
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int ProgramId { get; set; }
        public Program Program { get; set; }

        public int OrderNumber { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public List<ItemProgramStudent> ItemProgramStudents { get; set; } = new();

    }
}
