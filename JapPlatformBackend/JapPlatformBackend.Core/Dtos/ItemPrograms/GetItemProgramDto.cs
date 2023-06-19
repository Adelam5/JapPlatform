using JapPlatformBackend.Core.Dtos.Item;

namespace JapPlatformBackend.Core.Dtos.ItemPrograms
{
    public class GetItemProgramDto
    {
        public int OrderNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public GetItemDto Item { get; set; }
    }
}
