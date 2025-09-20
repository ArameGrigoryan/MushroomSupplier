using Microsoft.AspNetCore.Mvc;
using MushroomSupplier.Core.DTOs;
using MushroomSupplier.Core.Interfaces;
using MushroomSupplier.Core.Models.Enums;

namespace MushroomSupplier.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDto>> GetById(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateOrderDto createOrderDto)
    {
        var orderDto = await _orderService.CreateOrderAsync(createOrderDto);
        return CreatedAtAction(nameof(GetById), new { id = orderDto.Id }, orderDto);
    }


    [HttpPut("{id}/status")]
    public async Task<ActionResult> UpdateStatus(int id, [FromBody] OrderStatus status)
    {
        await _orderService.UpdateOrderStatusAsync(id, status);
        return NoContent();
    }
}