using System.Net;

namespace JapPlatformBackend.Api.Exceptions
{
    public class UnauthenticatedException : JapPlatformException
    {
        public UnauthenticatedException() : base("User is not authenticated", HttpStatusCode.Unauthorized) { }

        public UnauthenticatedException(string message) : base(message, HttpStatusCode.Unauthorized)
        {

        }

    }
}
