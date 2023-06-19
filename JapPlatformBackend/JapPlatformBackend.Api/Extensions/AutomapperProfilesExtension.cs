using JapPlatformBackend.Core.MapperProfiles;

namespace JapPlatformBackend.Api.Extensions
{
    public static class AutomapperProfilesExtension
    {
        public static void RegisterAutomapperProfiles(this IServiceCollection service)
        {

            service.AddAutoMapper(typeof(UserProfile));
            service.AddAutoMapper(typeof(StudentProfile));
            service.AddAutoMapper(typeof(SelectionProfile));
            service.AddAutoMapper(typeof(ProgramProfile));
            service.AddAutoMapper(typeof(CommentProfile));
            service.AddAutoMapper(typeof(ReportProfile));
        }
    }
}
