using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MushroomSupplier.Core.Models;

namespace MushroomSupplier.Infrastructure.EntityConfigurations;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(r => r.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(r => r.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(r => r.Phone)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasMany(r => r.Orders)
            .WithOne(o => o.Restaurant)
            .HasForeignKey(o => o.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Profile)
            .WithOne(p => p.Restaurant)
            .HasForeignKey<RestaurantProfile>(p => p.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}