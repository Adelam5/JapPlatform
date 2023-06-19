using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace JapPlatformBackend.Api.Extensions
{
    public static class SwaggerExtension
    {
        public static void RegisterSwagger(this IServiceCollection service)
        {
            service.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Jap Platform", Version = "v1" });
                option.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }
    }
}
