using JapPlatformBackend.Core.Interfaces;
using JapPlatformBackend.Core.Interfaces.Repositories;
using JapPlatformBackend.Repositories;
using JapPlatformBackend.Services;

namespace JapPlatformBackend.Api.Extensions
{
    public static class ServicesExtension
    {
        public static void RegisterServices(this IServiceCollection service)
        {
            service.AddTransient<IProgramService, ProgramService>();
            service.AddTransient<IStudentService, StudentService>();
            service.AddTransient<ISelectionService, SelectionService>();
            service.AddTransient<IAuthService, AuthService>();
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<IAdminService, AdminService>();
            service.AddTransient<IMailService, MailService>();
            service.AddTransient<IItemService, ItemService>();
            service.AddTransient<ILectureService, LectureService>();

            service.AddTransient<ISelectionRepository, SelectionRepository>();
            service.AddTransient<IStudentRepository, StudentRepository>();
            service.AddTransient<IProgramRepository, ProgramRepository>();
            service.AddTransient<IItemRepository, ItemRepository>();
            service.AddTransient<ILectureRepository, LectureRepository>();
        }
    }
}
