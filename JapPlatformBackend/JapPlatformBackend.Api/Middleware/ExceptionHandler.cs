using JapPlatformBackend.Api.Exceptions;
using System.Net;
using System.Text.Json;

namespace JapPlatformBackend.Api.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandler> logger;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var response = context.Response;

            try
            {
                await next(context);

                if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
                    throw new UnauthenticatedException();

                if (response.StatusCode == (int)HttpStatusCode.Forbidden)
                    throw new UnauthorizedException();

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                response.ContentType = "application/json";

                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                if (ex is JapPlatformException exception)
                {
                    response.StatusCode = (int)exception.StatusCode;
                }

                var result = JsonSerializer.Serialize(new
                {
                    success = false,
                    message = ex.Message
                });

                await response.WriteAsync(result);
            }
        }
    }
}
