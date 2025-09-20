using MushroomSupplier.Core.DTOs;

namespace MushroomSupplier.Core.Interfaces;

public interface IRestaurantService
{
    Task<IEnumerable<RestaurantDto>> GetAll();
    Task<RestaurantDto?> GetId(int id);
    Task<RestaurantDto> CreateRestaurant(CreateRestaurantDto dto);
    Task UpdateRestaurant(RestaurantDto restaurantDto);
    Task DeleteRestaurant(int id);
}