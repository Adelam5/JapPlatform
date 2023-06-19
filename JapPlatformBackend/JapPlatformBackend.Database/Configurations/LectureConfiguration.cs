using JapPlatformBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JapPlatformBackend.Database.Configurations
{
    public class LectureConfiguration : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {

            //modelBuilder.Entity<Lecture>()
            //.Property(e => e.Urls)
            //.HasConversion(
            //    v => string.Join(',', v),
            //    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));


            builder.HasData(
                new Lecture
                {
                    Id = 1,
                    Name = "React Course",
                    Description = "Description of the React Course",
                    WorkHours = 20,
                    Urls = "udemy.com"
                },
                new Lecture
                {
                    Id = 2,
                    Name = ".Net Course",
                    Description = ".Net Course Description",
                    WorkHours = 30,
                    Urls = "udemy.com"
                },
                new Lecture
                {
                    Id = 3,
                    Name = "Postman Course",
                    Description = "Course Description",
                    WorkHours = 10,
                    Urls = "udemy.com"
                },
                new Lecture
                {
                    Id = 4,
                    Name = "xUnit Course",
                    Description = "Course Description",
                    WorkHours = 10,
                    Urls = "udemy.com"
                },
                new Lecture
                {
                    Id = 5,
                    Name = "Docker Course",
                    Description = "Course Description",
                    WorkHours = 20,
                    Urls = "udemy.com"
                });
        }
    }
}
