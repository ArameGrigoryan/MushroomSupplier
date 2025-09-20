using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MushroomSupplier.Core.Models;

namespace MushroomSupplier.Infrastructure.EntityConfigurations;

public class RestaurantProfileConfiguration : IEntityTypeConfiguration<RestaurantProfile>
{
    public void Configure(EntityTypeBuilder<RestaurantProfile> builder)
    {
        builder.HasKey(rp => rp.Id);

        builder.Property(rp => rp.Address)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(rp => rp.ContactPerson)
            .HasMaxLength(50)
            .IsRequired();
    }
}