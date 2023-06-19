using JapPlatformBackend.Core.Entities;
using JapPlatformBackend.Database;
using Microsoft.AspNetCore.Identity;

namespace JapPlatformBackend.Api.Extensions
{
    public static class IdentityExtension
    {
        public static void RegisterIdentity(this IServiceCollection service)
        {
            service.AddIdentityCore<User>()
                .AddRoles<Role>()
                .AddRoleManager<RoleManager<Role>>()
                .AddSignInManager<SignInManager<User>>()
                .AddRoleValidator<RoleValidator<Role>>()
                .AddEntityFrameworkStores<DataContext>();

            var passwordOptions = new PasswordOptions()
            {
                RequireDigit = false,
                RequireLowercase = false,
                RequiredLength = 4,
                RequireNonAlphanumeric = false,
                RequireUppercase = false,
            };

            service.Configure<IdentityOptions>(opt =>
            {
                opt.Password = passwordOptions;
            });
        }
    }
}
