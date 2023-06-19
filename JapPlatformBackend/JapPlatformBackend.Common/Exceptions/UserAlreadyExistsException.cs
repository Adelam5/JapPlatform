using System.Net;

namespace JapPlatformBackend.Api.Exceptions
{
    public class UserAlreadyExistsException : JapPlatformException
    {
        public UserAlreadyExistsException() : base("User already exists", HttpStatusCode.BadRequest)
        {
        }

        public UserAlreadyExistsException(string message) : base(message, HttpStatusCode.BadRequest)
        {
        }



    }
}
