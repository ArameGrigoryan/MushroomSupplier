namespace MushroomSupplier.Core.Models;
public class SupplierProduct
{
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public string SupplierSku { get; set; } = null!;
}