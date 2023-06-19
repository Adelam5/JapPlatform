using AutoMapper;
using JapPlatformBackend.Core.Dtos.UserRole;
using JapPlatformBackend.Core.Entities;

namespace server.MapperProfiles
{
    public class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            CreateMap<UserRole, UserRoleDto>();
        }
    }
}
