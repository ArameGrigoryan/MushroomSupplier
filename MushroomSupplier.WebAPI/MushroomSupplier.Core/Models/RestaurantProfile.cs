namespace MushroomSupplier.Core.Models;

public class RestaurantProfile
{
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public string? Address { get; set; }
    public string? ContactPerson { get; set; } = null;

    public Restaurant Restaurant { get; set; } = null!;
}