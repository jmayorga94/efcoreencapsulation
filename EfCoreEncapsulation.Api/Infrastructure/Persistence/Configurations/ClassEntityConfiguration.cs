using EfCoreEncapsulation.Api.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreEncapsulation.Api.Infrastructure.Persistence.Configurations
{
    public class ClassEntityConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Classes");

            builder.HasKey(m => m.Id)
                   .HasName("ClassId");

            builder.Property(m => m.Id)
                   .HasColumnName("ClassId");
         
            builder.Property(m => m.ClassName)
                   .HasColumnName("Name");

            builder.HasMany(m => m.Enrollments)
                   .WithOne(e => e.Class);
        }
    }
}
