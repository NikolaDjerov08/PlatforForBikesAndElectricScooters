using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PlatformForBikesAndElectricScooters.Models.Enums;

namespace PlatformForBikesAndElectricScooters.Models;

public class Vehicle
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Model { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string Brand { get; set; } = null!;

    public VehicleType Type { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, 1000)]
    public decimal PricePerHour { get; set; }

    // Battery level in percent; null for regular (non-electric) bikes.
    [Range(0, 100)]
    public int? BatteryLevel { get; set; }

    public bool IsAvailable { get; set; } = true;

    [MaxLength(500)]
    public string? ImageUrl { get; set; }

    // The station where the vehicle is parked; null while it is rented.
    public int? StationId { get; set; }

    public Station? Station { get; set; }
}
