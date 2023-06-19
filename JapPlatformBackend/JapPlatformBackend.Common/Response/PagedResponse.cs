namespace JapPlatformBackend.Common.Response
{
    public class PagedResponse<T> : ServiceResponse<T>
    {
        public int Pages { get; set; }
    }
}
