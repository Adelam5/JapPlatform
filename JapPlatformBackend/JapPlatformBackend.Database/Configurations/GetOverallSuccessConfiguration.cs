using JapPlatformBackend.Core.Dtos.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JapPlatformBackend.Database.Configurations
{
    public class GetOverallSuccessConfiguration : IEntityTypeConfiguration<GetOverallSuccess>
    {
        public void Configure(EntityTypeBuilder<GetOverallSuccess> builder)
        {
            builder
               .ToTable("GetOverallSuccess", t => t.ExcludeFromMigrations())
               .HasNoKey();
        }
    }
}
