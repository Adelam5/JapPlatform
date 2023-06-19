using AutoMapper;
using JapPlatformBackend.Core.Dtos.Program;
using JapPlatformBackend.Core.Entities;

namespace JapPlatformBackend.Core.MapperProfiles
{
    public class ProgramProfile : Profile
    {
        public ProgramProfile()
        {
            CreateMap<Program, GetProgramDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.ItemPrograms))
                .ReverseMap();

            CreateMap<GetProgramDto, GetReductedProgramDto>().ReverseMap();

            CreateMap<Program, CreateProgramDto>().ReverseMap();

            CreateMap<Program, UpdateProgramDto>().ReverseMap();
        }
    }
}
