using JapPlatformBackend.Core.Entities.Base;

namespace JapPlatformBackend.Core.Entities
{
    public class Comment : AuditableEntity
    {
        public string Text { get; set; } = string.Empty;

        public int? AuthorId { get; set; }
        public User? Author { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
