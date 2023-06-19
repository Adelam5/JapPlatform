using JapPlatformBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JapPlatformBackend.Database.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(r => r.UserRoles)
                   .WithOne(r => r.Role)
                   .HasForeignKey(r => r.RoleId)
                   .IsRequired();

            builder.HasData(
                new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN".ToUpper() },
                new Role { Id = 2, Name = "Student", NormalizedName = "STUDENT".ToUpper() }
                );
        }
    }
}
