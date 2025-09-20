using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MushroomSupplier.Core.Models;

namespace MushroomSupplier.Infrastructure.Data;

public class MushroomContext : DbContext
{
    public MushroomContext(DbContextOptions<MushroomContext> options) : base(options) { }

    public MushroomContext()
    {
    }
    public DbSet<Restaurant> Restaurants { get; set; } = null!;
    public DbSet<RestaurantProfile> RestaurantProfiles { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Supplier> Suppliers { get; set; } = null!;
    public DbSet<SupplierProduct> SupplierProducts { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MushroomDb;Username=Arame;Password=1111");
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        // modelBuilder.Entity<Restaurant>()
        //     .HasOne(r => r.Profile)
        //     .WithOne(p => p.Restaurant)
        //     .HasForeignKey<RestaurantProfile>(p => p.RestaurantId)
        //     .OnDelete(DeleteBehavior.Cascade);
        //
        // modelBuilder.Entity<Order>()
        //     .HasOne(o => o.Restaurant)
        //     .WithMany(r => r.Orders)
        //     .HasForeignKey(o => o.RestaurantId)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // modelBuilder.Entity<OrderItem>()
        //     .HasKey(oi => new { oi.OrderId, oi.ProductId });
        //
        // modelBuilder.Entity<OrderItem>()
        //     .HasOne(oi => oi.Order)
        //     .WithMany(o => o.Items)
        //     .HasForeignKey(oi => oi.OrderId);
        //
        // modelBuilder.Entity<OrderItem>()
        //     .HasOne(oi => oi.Product)
        //     .WithMany(p => p.OrderItems)
        //     .HasForeignKey(oi => oi.ProductId);
        //
        // modelBuilder.Entity<SupplierProduct>()
        //     .HasKey(sp => new { sp.SupplierId, sp.ProductId });
        //
        // modelBuilder.Entity<SupplierProduct>()
        //     .HasOne(sp => sp.Supplier)
        //     .WithMany(s => s.SupplierProducts)
        //     .HasForeignKey(sp => sp.SupplierId);
        //
        // modelBuilder.Entity<SupplierProduct>()
        //     .HasOne(sp => sp.Product)
        //     .WithMany(p => p.SupplierProducts)
        //     .HasForeignKey(sp => sp.ProductId);
        //
        // modelBuilder.Entity<Order>()
        //     .HasIndex(o => o.RestaurantId);
        //
        // modelBuilder.Entity<Order>()
        //     .HasIndex(o => o.CreatedAt);
        //
        // modelBuilder.Entity<Product>()
        //     .HasIndex(p => p.Name);
        //
        // modelBuilder.Entity<Restaurant>()
        //     .HasIndex(r => r.Email).IsUnique();
        //
        // modelBuilder.Entity<Product>()
        //     .Property(p => p.Price)
        //     .HasColumnType("numeric(10,2)")
        //     .IsRequired();



    }
}