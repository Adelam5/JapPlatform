using AutoMapper;
using JapPlatformBackend.Core.Dtos.ItemPrograms;
using JapPlatformBackend.Core.Entities;

namespace JapPlatformBackend.Core.MapperProfiles
{
    public class ItemProgramProfile : Profile
    {
        public ItemProgramProfile()
        {
            CreateMap<ItemProgram, GetItemProgramDto>().ReverseMap();
            CreateMap<ItemProgram, CreateItemProgramDto>().ReverseMap();
        }
    }
}
