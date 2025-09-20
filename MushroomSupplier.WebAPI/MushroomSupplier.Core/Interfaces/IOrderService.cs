using MushroomSupplier.Core.DTOs;
using MushroomSupplier.Core.Models.Enums;

namespace MushroomSupplier.Core.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllOrdersAsync();

    Task<OrderDto?> GetOrderByIdAsync(int id);

    Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto);

    Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus);

    Task DeleteOrderAsync(int orderId);

    Task<IEnumerable<OrderDto>> GetOrdersByRestaurantAsync(int restaurantId);

    Task<IEnumerable<OrderDto>> GetOrdersByStatusAsync(OrderStatus status);
}