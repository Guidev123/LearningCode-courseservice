using Courses.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Courses.Data.Mappings
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasColumnType("VARCHAR(50)");
            builder.Property(x => x.Description).IsRequired().HasColumnType("VARCHAR(255)");
            builder.Property(x => x.IsDeleted).IsRequired().HasColumnType("BIT");
            builder.Property(x => x.CreatedAt).IsRequired().HasColumnType("DATETIME2");
            builder.HasMany(x => x.Modules).WithOne(x => x.Course).HasForeignKey(x => x.CourseId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
