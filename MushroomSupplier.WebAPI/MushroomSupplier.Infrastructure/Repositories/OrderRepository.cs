using Microsoft.EntityFrameworkCore;
using MushroomSupplier.Core.Interfaces;
using MushroomSupplier.Core.Models;
using MushroomSupplier.Core.Models.Enums;
using MushroomSupplier.Infrastructure.Data;

namespace MushroomSupplier.Infrastructure.Repositories;
public class OrderRepository : Repository<Order>, IOrderRepository
{
    private readonly MushroomContext _mushroomContext;

    public OrderRepository(MushroomContext context) : base(context)
    {
        _mushroomContext = context;
    }

    public async Task<IEnumerable<Order>> GetOrdersByRestaurantIdAsync(int restaurantId)
    {
        return await _mushroomContext.Orders
            .Include(o => o.Items)
            .Where(o => o.RestaurantId == restaurantId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
    {
        return await _mushroomContext.Orders
            .Include(o => o.Items)
            .Where(o => o.Status == status)
            .ToListAsync();
    }
}