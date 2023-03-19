using Company.Delivery.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Delivery.Database.ModelConfigurations;

internal class WaybillConfiguration : IEntityTypeConfiguration<Waybill>
{
    public void Configure(EntityTypeBuilder<Waybill> builder)
    {
        builder.Property(s => s.Number).HasMaxLength(10);
        builder.HasIndex(s=>s.Number)
            .IsUnique();
    }
}