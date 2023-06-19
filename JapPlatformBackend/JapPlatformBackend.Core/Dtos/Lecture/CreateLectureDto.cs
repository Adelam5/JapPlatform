namespace JapPlatformBackend.Core.Dtos.Lecture
{
    public class CreateLectureDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int WorkHours { get; set; }
        public string Urls { get; set; }
    }
}
