namespace MushroomSupplier.Core.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Variety { get; set; } = null!;
    public decimal UnitPrice { get; set; }
    public int AvailableQuantity { get; set; }
}


public class CreateProductDto
{
    public string Name { get; set; } = null!;
    public string Variety { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}