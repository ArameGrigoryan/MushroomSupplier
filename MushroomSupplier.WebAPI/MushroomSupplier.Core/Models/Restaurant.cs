using System.ComponentModel.DataAnnotations;

namespace MushroomSupplier.Core.Models;
public class Restaurant
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public string? Phone { get; set; }
    
    public RestaurantProfile? Profile { get; set; }
    public IEnumerable<Order> Orders { get; set; }
}