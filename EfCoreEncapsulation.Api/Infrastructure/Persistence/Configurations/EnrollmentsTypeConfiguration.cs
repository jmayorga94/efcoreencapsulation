using EfCoreEncapsulation.Api.Enrollments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreEncapsulation.Api.Infrastructure.Persistence.Configurations
{
    public class EnrollmentsTypeConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => new { e.MemberId, e.ClassId }).HasName("PK_Enrollments");
            builder.Property(e => e.MemberId);
            builder.Property(e => e.ClassId);

            builder.HasOne(e => e.Member)
                  .WithMany();

            builder.HasOne(e => e.Class)
                  .WithMany(c => c.Enrollments);
        }
    }
}
