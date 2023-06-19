namespace JapPlatformBackend.Core.Dtos.Item
{
    public class CreateEventDto
    {
        public int ProgramId { get; set; }
        public int OrderNumber { get; set; }
        public string Name { get; set; }
        public int WorkHours { get; set; }

    }
}
