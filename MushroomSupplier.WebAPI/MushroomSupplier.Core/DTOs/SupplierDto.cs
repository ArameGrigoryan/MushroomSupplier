namespace MushroomSupplier.Core.DTOs;

public class SupplierDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}

public class CreateSupplierDto
{
    public string Name { get; set; } = null!;
}
