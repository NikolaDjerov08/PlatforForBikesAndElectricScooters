using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PlatformForBikesAndElectricScooters.Models;

public class ApplicationUser : IdentityUser
{
    [MaxLength(50)]
    public string? FirstName { get; set; }

    [MaxLength(50)]
    public string? LastName { get; set; }

    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
