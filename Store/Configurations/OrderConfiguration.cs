using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Records;

namespace Store.Configurations;

internal sealed class OrderConfiguration : IEntityTypeConfiguration<OrderRecord>
{
    public void Configure(EntityTypeBuilder<OrderRecord> builder)
    {
        builder.ToTable("orders");

        builder.HasKey(o => o.Number);
        builder.Property(o => o.Number)
            .IsRequired();

        builder.Property(o => o.SenderCity)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(o => o.SenderAddress)
            .IsRequired()
            .HasMaxLength(512);

        builder.Property(o => o.RecipientCity)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(o => o.RecipientAddress)
            .IsRequired()
            .HasMaxLength(512);

        builder.Property(o => o.Weight)
            .IsRequired()
            .HasPrecision(18, scale: 3);

        builder.Property(o => o.PickupDate)
            .IsRequired();
    }
}