using JapPlatformBackend.Common.Enums;
using JapPlatformBackend.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JapPlatformBackend.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {

            builder
                .HasOne(s => s.Selection)
                .WithMany(s => s.Students)
                .HasForeignKey(s => s.SelectionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(s => s.Comments)
                .WithOne(c => c.Student)
                .HasForeignKey(s => s.StudentId);

            builder
                .HasMany(s => s.ItemPrograms)
                .WithMany(s => s.Students)
                .UsingEntity<ItemProgramStudent>(
                    j => j
                        .HasOne(ips => ips.ItemProgram)
                        .WithMany(ip => ip.ItemProgramStudents)
                        .HasForeignKey(ips => ips.ItemProgramId)
                        .OnDelete(DeleteBehavior.ClientNoAction),
                    j => j
                        .HasOne(ips => ips.Student)
                        .WithMany(s => s.ItemProgramStudents)
                        .HasForeignKey(ips => ips.StudentId),
                    j =>
                    {
                        j.Property(ips => ips.Progress).HasDefaultValue(0);
                        j.Property(ips => ips.ProgressStatus).HasDefaultValue(ProgressStatus.NotStarted);
                        j.HasKey(ip => new { ip.ItemProgramId, ip.StudentId });
                    }
                );

            var hashier = new PasswordHasher<User>();

            builder.HasData(
                new Student
                {
                    Id = 2,
                    UserName = "john",
                    PasswordHash = hashier.HashPassword(null, "string"),
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "mail@mail.com",
                    BirthDate = new DateTime(1994, 09, 12),
                    Status = StudentStatus.InProgram,
                    SelectionId = 1
                },
                new Student
                {
                    Id = 3,
                    UserName = "jane",
                    PasswordHash = hashier.HashPassword(null, "string"),
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "mail@mail.com",
                    BirthDate = new DateTime(1998, 09, 12),
                    Status = StudentStatus.Success,
                    SelectionId = 1
                },
                new Student
                {
                    Id = 4,
                    UserName = "jessica",
                    PasswordHash = hashier.HashPassword(null, "string"),
                    FirstName = "Jessica",
                    LastName = "Jones",
                    Email = "mail@mail.com",
                    BirthDate = new DateTime(1993, 07, 12),
                    Status = StudentStatus.Extended,
                    SelectionId = 2
                },
                new Student
                {
                    Id = 5,
                    UserName = "bruce",
                    PasswordHash = hashier.HashPassword(null, "string"),
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    Email = "mail@mail.com",
                    BirthDate = new DateTime(2001, 03, 12),
                    Status = StudentStatus.Success,
                    SelectionId = 2
                },
                new Student
                {
                    Id = 6,
                    UserName = "matt",
                    PasswordHash = hashier.HashPassword(null, "string"),
                    FirstName = "Matt",
                    LastName = "Murdock",
                    Email = "mail@mail.com",
                    BirthDate = new DateTime(1990, 03, 12),
                    Status = StudentStatus.Success,
                    SelectionId = 2
                },
                new Student
                {
                    Id = 7,
                    UserName = "tony",
                    PasswordHash = hashier.HashPassword(null, "string"),
                    FirstName = "Tony",
                    LastName = "Stark",
                    Email = "mail@mail.com",
                    BirthDate = new DateTime(1985, 03, 12),
                    Status = StudentStatus.Failed,
                    SelectionId = 3
                }
                );
        }
    }
}
