using MushroomSupplier.Core.Models.Enums;
namespace MushroomSupplier.Core.Models;
public class Order
{
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; } = null!;
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public List<OrderItem> Items { get; set; } = new();
}