using JapPlatformBackend.Common;
using JapPlatformBackend.Common.Enums;
using JapPlatformBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JapPlatformBackend.Database.Configurations
{
    public class SelectionConfiguration : IEntityTypeConfiguration<Selection>
    {


        public void Configure(EntityTypeBuilder<Selection> builder)
        {
            builder
                .HasOne(s => s.Program)
                .WithMany(p => p.Selections)
                .HasForeignKey(s => s.ProgramId);

            builder
                .HasMany(s => s.Students)
                .WithOne(s => s.Selection)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(s => s.CreatedAt).HasDefaultValueSql(ValidationLimit.DATE_NOW);
            builder.Property(s => s.ModifiedAt).HasDefaultValueSql(ValidationLimit.DATE_NOW);

            builder.HasData(
               new Selection
               {
                   Id = 1,
                   Name = "JAP Dev 09/2022",
                   StartDate = new DateTime(2022, 09, 05),
                   EndDate = new DateTime(2022, 10, 23),
                   Status = SelectionStatus.Active,
                   ProgramId = 1
               },
               new Selection
               {
                   Id = 2,
                   Name = "JAP QA 09/2022",
                   StartDate = new DateTime(2022, 09, 05),
                   EndDate = new DateTime(2022, 10, 24),
                   Status = SelectionStatus.Active,
                   ProgramId = 2
               },
               new Selection
               {
                   Id = 3,
                   Name = "JAP DevOps 09/2022",
                   StartDate = new DateTime(2022, 09, 05),
                   EndDate = new DateTime(2022, 10, 25),
                   Status = SelectionStatus.Active,
                   ProgramId = 3
               }
            );
        }
    }
}
