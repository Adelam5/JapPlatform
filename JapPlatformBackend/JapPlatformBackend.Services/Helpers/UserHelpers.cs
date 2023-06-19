using JapPlatformBackend.Api.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace JapPlatformBackend.Services.Helpers
{
    public static class UserHelpers
    {


        public static int GetLoggedInUserId(IHttpContextAccessor httpContextAccessor)
        {
            bool isParsed = int.TryParse(httpContextAccessor
                           ?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);

            if (!isParsed) throw new ResourceNotFound("UserId");

            return userId;
        }
    }
}
