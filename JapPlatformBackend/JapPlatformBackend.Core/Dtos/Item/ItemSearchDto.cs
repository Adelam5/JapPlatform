﻿namespace JapPlatformBackend.Core.Dtos.Item
{
    public class ItemSearchDto
    {
        public string? Filter { get; set; }
        public string? Value { get; set; }
        public string? Sort { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}
