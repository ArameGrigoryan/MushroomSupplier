using MushroomSupplier.Core.Models;
using MushroomSupplier.Core.Models.Enums;

namespace MushroomSupplier.Core.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersByRestaurantIdAsync(int restaurantId);
    Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status);
}