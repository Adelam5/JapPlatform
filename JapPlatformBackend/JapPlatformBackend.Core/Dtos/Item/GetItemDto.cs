namespace JapPlatformBackend.Core.Dtos.Item
{
    public class GetItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Discriminator { get; set; }
        public int WorkHours { get; set; }
        public string? Urls { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
