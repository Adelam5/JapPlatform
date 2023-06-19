using JapPlatformBackend.Core.Dtos.User;

namespace JapPlatformBackend.Core.Dtos.Comment
{
    public class GetCommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public GetUserDto? Author { get; set; }
    }
}
