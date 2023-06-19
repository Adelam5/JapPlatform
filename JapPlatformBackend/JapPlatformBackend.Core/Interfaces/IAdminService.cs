using JapPlatformBackend.Common.Response;
using JapPlatformBackend.Core.Dtos.Admin;

namespace JapPlatformBackend.Core.Interfaces
{
    public interface IAdminService
    {
        Task<ServiceResponse<GetReport>> GetReport();

        Task SendEmailReport();

    }
}
