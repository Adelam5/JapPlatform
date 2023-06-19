using JapPlatformBackend.Core.Dtos.ItemPrograms;

namespace JapPlatformBackend.Core.Dtos.Program
{
    public class GetProgramDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<GetItemProgramDto> Items { get; set; } = new();
    }
}
