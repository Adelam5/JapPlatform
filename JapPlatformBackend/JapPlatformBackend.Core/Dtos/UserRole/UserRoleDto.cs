using JapPlatformBackend.Core.Dtos.Role;
using JapPlatformBackend.Core.Dtos.User;

namespace JapPlatformBackend.Core.Dtos.UserRole
{
    public class UserRoleDto
    {
        public GetUserDto User { get; set; }
        public RoleDto Role { get; set; }
    }
}
