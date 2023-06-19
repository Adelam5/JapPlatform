using JapPlatformBackend.Core.Dtos.ItemPrograms;

namespace JapPlatformBackend.Core.Dtos.Program
{
    public class UpdateProgramDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<CreateItemProgramDto> ItemPrograms { get; set; }
    }
}
