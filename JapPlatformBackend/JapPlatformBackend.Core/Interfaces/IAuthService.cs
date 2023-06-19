using JapPlatformBackend.Common.Response;
using JapPlatformBackend.Core.Dtos.Auth;

namespace JapPlatformBackend.Core.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<LoginResponseDto>> Login(string username, string password);
        ServiceResponse<int> Logout();
    }
}
