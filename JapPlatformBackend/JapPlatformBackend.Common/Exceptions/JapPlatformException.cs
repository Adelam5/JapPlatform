using System.Net;

namespace JapPlatformBackend.Api.Exceptions
{
    public class JapPlatformException : Exception
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.InternalServerError;
        public JapPlatformException() : base()
        {
        }

        public JapPlatformException(string message) : base(message)
        {
        }

        public JapPlatformException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
