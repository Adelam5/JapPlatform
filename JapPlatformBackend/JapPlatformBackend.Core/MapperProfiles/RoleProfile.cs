using AutoMapper;
using JapPlatformBackend.Core.Dtos.Role;
using JapPlatformBackend.Core.Entities;

namespace server.MapperProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>();
        }
    }
}
