namespace MushroomSupplier.Core.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Variety { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public ICollection<SupplierProduct> SupplierProducts { get; set; } = new List<SupplierProduct>();
}
