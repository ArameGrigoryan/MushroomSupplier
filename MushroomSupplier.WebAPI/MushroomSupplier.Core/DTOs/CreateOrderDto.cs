namespace MushroomSupplier.Core.DTOs;

public class CreateOrderItemDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class CreateOrderDto
{
    public int RestaurantId { get; set; }
    public List<CreateOrderItemDto> Items { get; set; } = new();
}