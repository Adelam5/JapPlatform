using JapPlatformBackend.Common;
using JapPlatformBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JapPlatformBackend.Database.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasOne(c => c.Student)
                .WithMany(s => s.Comments)
                .HasForeignKey(c => c.Student.Id);

            builder
                .HasOne(c => c.Author)
                .WithMany()
                .HasForeignKey(c => c.AuthorId);

            builder.Property(s => s.CreatedAt).HasDefaultValueSql(ValidationLimit.DATE_NOW);
            builder.Property(s => s.ModifiedAt).HasDefaultValueSql(ValidationLimit.DATE_NOW);
        }
    }
}
