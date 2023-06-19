namespace JapPlatformBackend.Core.Dtos.Lecture
{
    public class GetLectureDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WorkHours { get; set; }
        public string Urls { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
}
