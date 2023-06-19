using JapPlatformBackend.Common.Enums;
using JapPlatformBackend.Core.Dtos.Program;

namespace JapPlatformBackend.Core.Dtos.Selection
{
    public class GetReductedSelectionDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SelectionStatus Status { get; set; }
        public GetReductedProgramDto? Program { get; set; }
    }
}
