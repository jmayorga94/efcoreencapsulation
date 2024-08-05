using EfCoreEncapsulation.Api.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreEncapsulation.Api.Infrastructure.Persistence.Configurations;

public class PaymentEntityConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments")
               .HasKey(m => m.PaymentId)
               .HasName("PK_PaymentId");

        builder.Property(m => m.PaymentDate);

        builder.Property(m => m.Amount);

        builder.HasOne(m => m.Member)
               .WithMany(p=>p.Payments);

    }
}
