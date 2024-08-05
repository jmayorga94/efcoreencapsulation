using EfCoreEncapsulation.Api.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreEncapsulation.Api.Infrastructure.Persistence.Configurations
{
    public class MembersTypeConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members");

            builder.HasKey(m => m.MemberId).HasName("PK_Members");

            builder.Property(m=>m.Name)
                   .HasColumnName("Name");

            builder.Property(m => m.MembershipStartDate)
                   .HasColumnName("StartDate");

            builder.HasMany(m => m.Enrollments)
                   .WithOne(e => e.Member);

            builder.HasMany(m => m.Payments)
                  .WithOne(e => e.Member);

            builder.Navigation(m => m.Enrollments).AutoInclude(); //This helps simplifying the query to members by including enrollments
        }
    }
}
