﻿namespace JapPlatformBackend.Core.Dtos.Item
{
    public class CreateItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int WorkHours { get; set; }
        public string Discriminator { get; set; }
    }
}
