using JapPlatformBackend.Core.Entities.Base;

namespace JapPlatformBackend.Core.Entities
{
    public class Program : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Selection>? Selections { get; set; }
        public ICollection<Item> Items { get; set; } = new List<Item>();
        public List<ItemProgram> ItemPrograms { get; set; } = new();

    }
}
