using Courses.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Courses.Data.Mappings
{
    public class ModuleMapping : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.ToTable("Modules");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasColumnType("VARCHAR(50)");
            builder.Property(x => x.Description).IsRequired().HasColumnType("VARCHAR(255)");
            builder.Property(x => x.IsDeleted).IsRequired().HasColumnType("BIT");
            builder.Property(x => x.CreatedAt).IsRequired().HasColumnType("DATETIME2");
            builder.HasMany(x => x.Lessons).WithOne(x => x.Module).HasForeignKey(x => x.ModuleId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
