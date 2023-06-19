using System.Net;

namespace JapPlatformBackend.Api.Exceptions
{
    public class BadRequestException : JapPlatformException
    {
        public BadRequestException() : base("Bad request", HttpStatusCode.BadRequest)
        {

        }
        public BadRequestException(string message) : base(message, HttpStatusCode.BadRequest)
        {

        }

    }
}
