namespace JapPlatformBackend.Common
{
    public class BaseSearch
    {
        public string? Filter { get; set; }
        public string? Value { get; set; }
        public string? Sort { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string? Includes { get; set; }
    }
}
