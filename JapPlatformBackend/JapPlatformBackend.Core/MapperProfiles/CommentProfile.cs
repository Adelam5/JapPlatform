using AutoMapper;
using JapPlatformBackend.Core.Dtos.Comment;
using JapPlatformBackend.Core.Entities;

namespace JapPlatformBackend.Core.MapperProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, GetCommentDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
        }
    }
}
