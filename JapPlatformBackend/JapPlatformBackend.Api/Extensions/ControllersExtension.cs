using Newtonsoft.Json.Converters;

namespace JapPlatformBackend.Api.Extensions
{
    public static class ControllersExtension
    {
        public static void RegisterControllers(this IServiceCollection service)
        {
            service.AddControllers()
                .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            });
        }
    }
}
