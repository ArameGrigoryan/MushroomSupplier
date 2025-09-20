namespace MushroomSupplier.Core.DTOs;
public class SupplierProductDto
{
    public int Id { get; set; }

    public int SupplierId { get; set; }

    public string? SupplierName { get; set; }

    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}