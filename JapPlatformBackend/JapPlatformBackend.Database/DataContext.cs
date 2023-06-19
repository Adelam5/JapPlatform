using JapPlatformBackend.Core.Dtos.Admin;
using JapPlatformBackend.Core.Entities;
using JapPlatformBackend.Core.Entities.Base;
using JapPlatformBackend.Database.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JapPlatformBackend.Database
{
    public class DataContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Program> Programs { get; set; } = null!;
        public DbSet<Selection> Selections { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<Lecture> Lectures { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<ItemProgram> ItemPrograms { get; set; } = null!;
        public DbSet<ItemProgramStudent> ItemProgramStudents { get; set; } = null!;
        public DbSet<GetSelectionsSuccess> GetSelectionsSuccess { get; set; } = null!;
        public DbSet<GetOverallSuccess> GetOverallSuccess { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Adding DB configurations and seed
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProgramConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new SelectionConfiguration());
            modelBuilder.ApplyConfiguration(new LectureConfiguration());
            modelBuilder.ApplyConfiguration(new GetSelectionsSuccessConfiguration());
            modelBuilder.ApplyConfiguration(new GetOverallSuccessConfiguration());
        }
    }
}
