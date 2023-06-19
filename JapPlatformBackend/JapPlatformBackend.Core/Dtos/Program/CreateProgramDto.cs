using JapPlatformBackend.Core.Dtos.ItemPrograms;

namespace JapPlatformBackend.Core.Dtos.Program
{
    public class CreateProgramDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CreateItemProgramDto> ItemPrograms { get; set; }
    }
}
