using JapPlatformBackend.Common.Response;
using JapPlatformBackend.Core.Dtos.User;

namespace JapPlatformBackend.Core.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<GetCurrentUserDto>> GetCurrentUser();
    }
}
