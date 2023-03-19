using Company.Delivery.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Delivery.Database.ModelConfigurations;

internal class CargoItemConfiguration : IEntityTypeConfiguration<CargoItem>
{
    public void Configure(EntityTypeBuilder<CargoItem> builder)
    {
        builder.Property(s => s.Name).HasMaxLength(100);
        builder.Property(s => s.Number).HasMaxLength(10);

        builder.HasIndex(s => new {s.WaybillId, s.Number}).IsUnique();
    }
}