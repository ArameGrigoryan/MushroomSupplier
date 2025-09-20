namespace MushroomSupplier.Core.Models;

public class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<SupplierProduct> SupplierProducts { get; set; } = new List<SupplierProduct>();
}