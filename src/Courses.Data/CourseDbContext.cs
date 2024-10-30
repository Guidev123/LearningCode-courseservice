using Courses.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Courses.Data
{
    public class CourseDbContext(DbContextOptions<CourseDbContext> options) : DbContext(options)
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(180)");

            builder.ApplyConfigurationsFromAssembly(typeof(CourseDbContext).Assembly);
        }
    }
}
