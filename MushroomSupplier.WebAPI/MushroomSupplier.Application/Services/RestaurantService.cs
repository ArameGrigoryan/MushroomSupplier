using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MushroomSupplier.Core.DTOs;
using MushroomSupplier.Core.Interfaces;
using MushroomSupplier.Core.Models;
using MushroomSupplier.Infrastructure.Data;

namespace MushroomSupplier.Application.Services;
public class RestaurantService : IRestaurantService
{
    private readonly MushroomContext _context;
    private readonly IMapper _mapper;

    public RestaurantService(MushroomContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RestaurantDto>> GetAll()
    {
        var restaurants = await _context.Restaurants.ToListAsync();
        return _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
    }
    

    

    public async Task<RestaurantDto?> GetId(int id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);
        if (restaurant == null) return null;
        return _mapper.Map<RestaurantDto>(restaurant);
    }

    public async Task<RestaurantDto> CreateRestaurant(CreateRestaurantDto dto)
    {
        var restaurant = _mapper.Map<Restaurant>(dto);
        _context.Restaurants.Add(restaurant);
        await _context.SaveChangesAsync();

        return _mapper.Map<RestaurantDto>(restaurant);
    }


    public async Task UpdateRestaurant(RestaurantDto restaurantDto)
    {
        var restaurant = await _context.Restaurants.FindAsync(restaurantDto.Id);
        if (restaurant == null)
            throw new KeyNotFoundException($"Restaurant with Id {restaurantDto.Id} not found");

        _mapper.Map(restaurantDto, restaurant);
        _context.Restaurants.Update(restaurant);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRestaurant(int id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);
        if (restaurant == null)
            throw new KeyNotFoundException($"Restaurant with Id {id} not found");

        _context.Restaurants.Remove(restaurant);
        await _context.SaveChangesAsync();
    }
}
