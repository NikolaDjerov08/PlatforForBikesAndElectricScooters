using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PlatformForBikesAndElectricScooters.Models.Enums;

namespace PlatformForBikesAndElectricScooters.Models;

public class Rental
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = null!;

    public ApplicationUser User { get; set; } = null!;

    public int VehicleId { get; set; }

    public Vehicle Vehicle { get; set; } = null!;

    public int StartStationId { get; set; }

    public Station StartStation { get; set; } = null!;

    // Set when the vehicle is returned.
    public int? EndStationId { get; set; }

    public Station? EndStation { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? TotalPrice { get; set; }

    public RentalStatus Status { get; set; } = RentalStatus.Active;

    public Review? Review { get; set; }
}
