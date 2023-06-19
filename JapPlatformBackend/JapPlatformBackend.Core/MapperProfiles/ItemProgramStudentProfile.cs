using AutoMapper;
using JapPlatformBackend.Core.Dtos.ItemProgramStudents;
using JapPlatformBackend.Core.Entities;

namespace JapPlatformBackend.Core.MapperProfiles
{
    public class ItemProgramStudentProfile : Profile
    {
        public ItemProgramStudentProfile()
        {
            CreateMap<ItemProgramStudent, ItemProgramStudentDto>()
                .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.ItemProgram.OrderNumber))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ItemProgram.Item.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ItemProgram.Item.Description))
                .ForMember(dest => dest.Discriminator, opt => opt.MapFrom(src => src.ItemProgram.Item.Discriminator))
                .ForMember(dest => dest.WorkHours, opt => opt.MapFrom(src => src.ItemProgram.Item.WorkHours))
                .ForMember(dest => dest.Urls, opt => opt.MapFrom(src => src.ItemProgram.Item.Urls))
                .ReverseMap();
        }
    }
}
