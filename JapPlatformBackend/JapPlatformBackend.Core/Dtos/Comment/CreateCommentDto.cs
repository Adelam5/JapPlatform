namespace JapPlatformBackend.Core.Dtos.Comment
{
    public class CreateCommentDto
    {
        public string Text { get; set; } = string.Empty;
        public int StudentId { get; set; }
    }
}
