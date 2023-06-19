using AutoMapper;
using JapPlatformBackend.Core.Dtos.Lecture;
using JapPlatformBackend.Core.Entities;

namespace JapPlatformBackend.Core.MapperProfiles
{
    public class LectureProfiles : Profile
    {
        public LectureProfiles()
        {
            CreateMap<Lecture, GetLectureDto>().ReverseMap();
            CreateMap<Lecture, CreateLectureDto>().ReverseMap();
            CreateMap<Lecture, UpdateLectureDto>().ReverseMap();
        }
    }
}
