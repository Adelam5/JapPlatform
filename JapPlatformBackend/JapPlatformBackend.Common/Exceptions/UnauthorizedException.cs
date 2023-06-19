using System.Net;

namespace JapPlatformBackend.Api.Exceptions
{
    public class UnauthorizedException : JapPlatformException
    {
        public UnauthorizedException() : base("User is not authorized", HttpStatusCode.Forbidden)
        {

        }
        public UnauthorizedException(string message) : base(message, HttpStatusCode.Forbidden)
        {

        }
    }
}
