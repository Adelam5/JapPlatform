using JapPlatformBackend.Core.Dtos.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JapPlatformBackend.Database.Configurations
{
    public class GetSelectionsSuccessConfiguration : IEntityTypeConfiguration<GetSelectionsSuccess>
    {
        public void Configure(EntityTypeBuilder<GetSelectionsSuccess> builder)
        {
            builder
                .ToTable("GetSelectionsSuccess", t => t.ExcludeFromMigrations())
                .HasNoKey();
        }
    }
}
