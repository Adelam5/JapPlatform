using AutoMapper;
using JapPlatformBackend.Common;
using JapPlatformBackend.Core.Dtos.Selection;
using JapPlatformBackend.Core.Entities;

namespace JapPlatformBackend.Core.MapperProfiles
{
    public class SelectionProfile : Profile
    {
        public SelectionProfile()
        {
            CreateMap<Selection, GetSelectionDto>().ReverseMap();

            CreateMap<GetSelectionDto, GetReductedSelectionDto>().ReverseMap();

            CreateMap<Selection, CreateSelectionDto>().ReverseMap();

            CreateMap<UpdateSelectionDto, Selection>();

            CreateMap<SelectionSearchDto, BaseSearch>()
                 .ForMember(dest => dest.Filter, opt =>
                 {
                     opt.MapFrom(src =>
                         src.Filter == "program" ? "program.name" :
                         src.Filter);
                 })
                .ForMember(dest => dest.Sort, opt =>
                {
                    opt.MapFrom(src =>
                        src.Sort == "program" ? "program.name" :
                        src.Sort == "program desc" ? "program.name desc" :
                        src.Sort);
                });
        }
    }
}
