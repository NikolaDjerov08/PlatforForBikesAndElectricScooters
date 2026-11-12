using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlatformForBikesAndElectricScooters.Models;

namespace PlatformForBikesAndElectricScooters.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Vehicle> Vehicles { get; set; } = null!;

    public DbSet<Station> Stations { get; set; } = null!;

    public DbSet<Rental> Rentals { get; set; } = null!;

    public DbSet<Review> Reviews { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Vehicle>()
            .HasOne(v => v.Station)
            .WithMany(s => s.Vehicles)
            .HasForeignKey(v => v.StationId)
            .OnDelete(DeleteBehavior.SetNull);

        // A rental points to two stations, so cascade delete is turned off
        // to avoid multiple cascade paths in SQL Server.
        builder.Entity<Rental>()
            .HasOne(r => r.StartStation)
            .WithMany()
            .HasForeignKey(r => r.StartStationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Rental>()
            .HasOne(r => r.EndStation)
            .WithMany()
            .HasForeignKey(r => r.EndStationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Rental>()
            .HasOne(r => r.Vehicle)
            .WithMany()
            .HasForeignKey(r => r.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Rental>()
            .HasOne(r => r.User)
            .WithMany(u => u.Rentals)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Review>()
            .HasOne(r => r.Rental)
            .WithOne(r => r.Review)
            .HasForeignKey<Review>(r => r.RentalId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
