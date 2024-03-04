using DatabaseModelClasses.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DatabaseModelClasses.Data;

public class ApplicationDbContext : IdentityDbContext<Member, CustomRole, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Member> Members { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Manifest> Manifests { get; set; }
    public DbSet<CustomRole> CustomRole { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //modelBuilder.Entity<IdentityUserRole<int>>().HasKey(p => new { p.UserId, p.RoleId });

        // Configure the name of the Users table to be "Members"
        modelBuilder.Entity<Member>().ToTable("Members");

        // Configure the name of the Roles table to be "CustomRole"
        modelBuilder.Entity<CustomRole>().ToTable("Roles");

        // Change the name of the Id column to "MemberId" because the default name is "Id" for IdentityRole<int>
       modelBuilder.Entity<Member>(entity => { entity.Property(m => m.Id).HasColumnName("MemberId"); });


        modelBuilder.Entity<CustomRole>().ToTable("CustomRole");
        //modelBuilder.Entity<CustomUser>().ToTable("CustomUser");
        modelBuilder.Seed();

        
        // Seed data for Vehicles
        modelBuilder.Entity<Vehicle>().HasData(
            new Vehicle
            {
                VehicleId = 1,
                Id = 1,
                Model = "Sedan",
                Make = "Generic",
                Year = 2020,
                NumberOfSeats = 4,
                VehicleType = "Economy",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = "Admin",
                ModifiedBy = "Admin"
            },
            new Vehicle
            {
                VehicleId = 2, 
                Id = 2, 
                Model = "Coupe", 
                Make = "FastCars", 
                Year = 2019, 
                NumberOfSeats = 2,
                VehicleType = "Sport", 
                Created = DateTime.Now, 
                Modified = DateTime.Now, 
                CreatedBy = "Admin",
                ModifiedBy = "Admin"
            },
            new Vehicle
            {
                VehicleId = 3, 
                Id = 3, 
                Model = "SUV", 
                Make = "BigCars", 
                Year = 2021, 
                NumberOfSeats = 6,
                VehicleType = "Luxury", 
                Created = DateTime.Now, 
                Modified = DateTime.Now, 
                CreatedBy = "Admin",
                ModifiedBy = "Admin"
            }
        );

        // Seed data for Trips
        modelBuilder.Entity<Trip>().HasData(
            new Trip
            {
                TripId = 1,
                VehicleId = 1,
                Date = new DateTime(2024, 4, 1),
                Time = new DateTime(1, 1, 1, 8, 0, 0),
                DestinationAddress = "100 Main St, Springfield",
                MeetingAddress = "150 Main St, Springfield",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = "Admin",
                ModifiedBy = "Admin"
            },
            new Trip
            {
                TripId = 2,
                VehicleId = 2,
                Date = new DateTime(2024, 4, 2),
                Time = new DateTime(1, 1, 1, 9, 0, 0),
                DestinationAddress = "200 Main St, Metropolis",
                MeetingAddress = "250 Main St, Metropolis",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = "Admin",
                ModifiedBy = "Admin"
            },
            new Trip
            {
                TripId = 3,
                VehicleId = 3,
                Date = new DateTime(2024, 4, 3),
                Time = new DateTime(1, 1, 1, 10, 0, 0),
                DestinationAddress = "300 Main St, Gotham",
                MeetingAddress = "350 Main St, Gotham",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = "Admin",
                ModifiedBy = "Admin"
            }
        );

        // Seed data for Manifests
        modelBuilder.Entity<Manifest>().HasData(
            new Manifest
            {
                ManifestId = 1, 
                Id = 1, 
                TripId = 1, 
                Notes = "John's trip.", 
                Created = DateTime.Now,
                Modified = DateTime.Now, 
                CreatedBy = "Admin", 
                ModifiedBy = "Admin"
            },
            new Manifest
            {
                ManifestId = 2, 
                Id = 2, 
                TripId = 2, 
                Notes = "Jane's trip.", 
                Created = DateTime.Now,
                Modified = DateTime.Now, 
                CreatedBy = "Admin", 
                ModifiedBy = "Admin"
            },
            new Manifest
            {
                ManifestId = 3, 
                Id = 3, 
                TripId = 3, 
                Notes = "Jim's trip.", 
                Created = DateTime.Now,
                Modified = DateTime.Now, 
                CreatedBy = "Admin", 
                ModifiedBy = "Admin"
            }
        );
    }
}