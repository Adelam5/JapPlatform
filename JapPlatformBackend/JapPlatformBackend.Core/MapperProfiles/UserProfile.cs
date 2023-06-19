using AutoMapper;
using JapPlatformBackend.Core.Dtos.User;
using JapPlatformBackend.Core.Entities;

namespace JapPlatformBackend.Core.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<User, GetCurrentUserDto>()
                .AfterMap((s, d) => d.Role = s.UserRoles.First().Role.Name);
        }
    }
}
