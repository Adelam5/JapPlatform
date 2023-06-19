using AutoMapper;
using JapPlatformBackend.Common;
using JapPlatformBackend.Core.Dtos.Item;
using JapPlatformBackend.Core.Entities.Base;

namespace JapPlatformBackend.Core.MapperProfiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<BaseSearch, ItemSearchDto>().ReverseMap();
            CreateMap<Item, GetItemDto>().ReverseMap();
            CreateMap<Item, CreateItemDto>().ReverseMap();
        }
    }
}
