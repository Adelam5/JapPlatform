using System.Net;

namespace JapPlatformBackend.Api.Exceptions
{
    public class ResourceNotFound : JapPlatformException
    {
        public ResourceNotFound() : base("Resource not found", HttpStatusCode.NotFound)
        {

        }
        public ResourceNotFound(string resource) : base($"{resource} not found", HttpStatusCode.NotFound)
        {

        }


    }
}
