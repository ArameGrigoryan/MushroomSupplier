using AutoMapper;
using MushroomSupplier.Core.DTOs;
using MushroomSupplier.Core.Interfaces;
using MushroomSupplier.Core.Models;
using MushroomSupplier.Core.Models.Enums;

namespace MushroomSupplier.Application.Services;
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
        var orders = await _orderRepository.GetAll();
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<OrderDto?> GetOrderByIdAsync(int id)
    {
        var order = await _orderRepository.GetId(id);
        if (order == null) return null;
        return _mapper.Map<OrderDto>(order);
    }

    public async Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto)
    {
        var order = _mapper.Map<Order>(createOrderDto);
        order.Status = OrderStatus.Pending;
        order.CreatedAt = DateTime.UtcNow;

        await _orderRepository.Add(order);

        return _mapper.Map<OrderDto>(order);
    }


    public async Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus)
    {
        var order = await _orderRepository.GetId(orderId);
        if (order == null) throw new KeyNotFoundException("Order not found");

        order.Status = newStatus;
        _orderRepository.Update(order);
    }

    public async Task DeleteOrderAsync(int orderId)
    {
        var order = await _orderRepository.GetId(orderId);
        if (order == null) throw new KeyNotFoundException("Order not found");

        _orderRepository.Delete(order);
    }

    public async Task<IEnumerable<OrderDto>> GetOrdersByRestaurantAsync(int restaurantId)
    {
        var orders = await _orderRepository.GetOrdersByRestaurantIdAsync(restaurantId);
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<IEnumerable<OrderDto>> GetOrdersByStatusAsync(OrderStatus status)
    {
        var orders = await _orderRepository.GetOrdersByStatusAsync(status);
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }
}