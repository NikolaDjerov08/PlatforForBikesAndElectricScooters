using System.ComponentModel.DataAnnotations;

namespace PlatformForBikesAndElectricScooters.Models;

public class Review
{
    public int Id { get; set; }

    // Each review belongs to one completed rental.
    public int RentalId { get; set; }

    public Rental Rental { get; set; } = null!;

    [Range(1, 5)]
    public int Rating { get; set; }

    [MaxLength(1000)]
    public string? Comment { get; set; }

    public DateTime CreatedOn { get; set; }
}
