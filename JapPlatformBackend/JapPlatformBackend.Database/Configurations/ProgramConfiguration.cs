using JapPlatformBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JapPlatformBackend.Database.Configurations
{
    public class ProgramConfiguration : IEntityTypeConfiguration<Program>
    {
        public void Configure(EntityTypeBuilder<Program> builder)
        {
            builder
                .HasMany(p => p.Selections)
                .WithOne(s => s.Program)
                .HasForeignKey(s => s.ProgramId);

            builder
                .HasMany(p => p.Items)
                .WithMany(p => p.Programs)
                .UsingEntity<ItemProgram>(
                    j => j
                        .HasOne(ip => ip.Item)
                        .WithMany(i => i.ItemPrograms)
                        .HasForeignKey(ip => ip.ItemId),
                    j => j
                        .HasOne(ip => ip.Program)
                        .WithMany(p => p.ItemPrograms)
                        .HasForeignKey(ip => ip.ProgramId),
                    j =>
                    {
                        j.Property(ip => ip.OrderNumber).HasDefaultValue(0);
                        j.HasIndex(ip => new { ip.ItemId, ip.ProgramId }).IsUnique();
                        //          j.HasKey(ip => new { ip.ProgramId, ip.ItemId });
                    });

            builder.HasData(
                new Program
                {
                    Id = 1,
                    Name = "JAP Dev",
                    Description = "Dev JAP is a 9-week program designed to prepare you for a full-time client engagement where you would work as a Junior Software Developer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities."
                },
                new Program
                {
                    Id = 2,
                    Name = "JAP QA",
                    Description = "QA JAP is a 5-week program designed to prepare you for a full-time client engagement where you would work as a Junior Quality Assurance engineer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities."
                },
                new Program
                {
                    Id = 3,
                    Name = "JAP DevOps",
                    Description = "DevOps JAP is a 13-week program designed to prepare you for a full-time client engagement where you would work as a Junior DevOps engineer within existing Mistral teams. The program is designed to fit your pace and will be completely personalized according to your current capabilities."
                }
            );
        }
    }
}
