using Microsoft.AspNetCore.Identity;

namespace JapPlatformBackend.Core.Entities
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
