using JapPlatformBackend.Common;
using JapPlatformBackend.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace JapPlatformBackend.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.CreatedAt).HasDefaultValueSql(ValidationLimit.DATE_NOW);
            builder.Property(u => u.ModifiedAt).HasDefaultValueSql(ValidationLimit.DATE_NOW);

            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(ValidationLimit.STRING_127);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(ValidationLimit.STRING_127);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(ValidationLimit.STRING_127);

            builder.HasMany(u => u.UserRoles)
                   .WithOne(u => u.User)
                   .HasForeignKey(u => u.UserId)
                   .IsRequired();

            var hashier = new PasswordHasher<User>();

            builder.HasData(
                new User
                {
                    Id = 1,
                    UserName = "admin",
                    PasswordHash = hashier.HashPassword(null, "admin"),
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "mail@mail.com",
                }
                );
        }
    }
}
