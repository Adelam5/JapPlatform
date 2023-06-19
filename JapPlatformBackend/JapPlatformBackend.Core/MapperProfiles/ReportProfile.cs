using AutoMapper;
using JapPlatformBackend.Core.Dtos.Admin;

namespace JapPlatformBackend.Core.MapperProfiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<GetSelectionsSuccess, GetReport>();
            CreateMap<GetOverallSuccess, GetReport>();

        }
    }
}
