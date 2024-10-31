using Courses.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Courses.Data.Mappings
{
    public class LessonMapping : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("Lesson");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasColumnType("VARCHAR(50)");
            builder.Property(x => x.LinkVideo).IsRequired().HasColumnType("NVARCHAR(255)");
            builder.Property(x => x.IsDeleted).IsRequired().HasColumnType("BIT");
            builder.Property(x => x.CreatedAt).IsRequired().HasColumnType("DATETIME2");
        }
    }
}
