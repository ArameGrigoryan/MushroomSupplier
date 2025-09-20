using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MushroomSupplier.Core.Models;

namespace MushroomSupplier.Infrastructure.EntityConfigurations;

public class SupplierProductConfiguration : IEntityTypeConfiguration<SupplierProduct>
{
    public void Configure(EntityTypeBuilder<SupplierProduct> builder)
    {
        builder.HasKey(sp => new { sp.SupplierId, sp.ProductId });

        builder.Property(sp => sp.SupplierSku)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(sp => sp.Supplier)
            .WithMany(s => s.SupplierProducts)
            .HasForeignKey(sp => sp.SupplierId);

        builder.HasOne(sp => sp.Product)
            .WithMany(p => p.SupplierProducts)
            .HasForeignKey(sp => sp.ProductId);
    }
}