using Microsoft.AspNetCore.Mvc;
using MushroomSupplier.Core.DTOs;
using MushroomSupplier.Core.Interfaces;

namespace MushroomSupplier.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RestaurantsController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;

    public RestaurantsController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll()
    {
        var restaurants = await _restaurantService.GetAll();
        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RestaurantDto>> GetId(int id)
    {
        var restaurant = await _restaurantService.GetId(id);
        return Ok(restaurant);
    }

    [HttpPost]
    public async Task<ActionResult<RestaurantDto>> Create([FromBody] CreateRestaurantDto dto)
    {
        var createdRestaurant = await _restaurantService.CreateRestaurant(dto);
        return CreatedAtAction(nameof(GetId), new { id = createdRestaurant.Id }, createdRestaurant);
    }





    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] RestaurantDto restaurantDto)
    {
        if (id != restaurantDto.Id)
            return BadRequest("Id mismatch");

        await _restaurantService.UpdateRestaurant(restaurantDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _restaurantService.DeleteRestaurant(id);
        return NoContent();
    }
}