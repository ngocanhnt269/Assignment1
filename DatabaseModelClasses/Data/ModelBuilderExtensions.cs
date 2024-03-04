using DatabaseModelClasses.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DatabaseModelClasses.Data;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder builder)
    {
        var pwd = "P@$$w0rd";
        var passwordHasher = new PasswordHasher<Member>();

        // Seed Roles
        var adminRole = new CustomRole("Admin");
        adminRole.Id = 1;
        adminRole.NormalizedName = adminRole.Name!.ToUpper();
        adminRole.Description = "Administrator Role";
        adminRole.CreatedDate = DateTime.Now;

        var ownerRole = new CustomRole("Owner");
        ownerRole.Id = 2;
        ownerRole.NormalizedName = ownerRole.Name!.ToUpper();
        ownerRole.Description = "Owner Role";
        ownerRole.CreatedDate = DateTime.Now;

        var passengerRole = new CustomRole("Passenger");
        passengerRole.Id = 3;
        passengerRole.NormalizedName = passengerRole.Name!.ToUpper();
        passengerRole.Description = "Passenger Role";
        passengerRole.CreatedDate = DateTime.Now;

        List<CustomRole> roles = new List<CustomRole>()
            {
                adminRole,
                ownerRole,
                passengerRole
            };

        builder.Entity<CustomRole>().HasData(roles);

        // Seed Users
        var adminUser = new Member
        {
            Id = 1,
            UserName = "a@a.a",
            Email = "a@a.a",
            EmailConfirmed = true,
            FirstName = "John",
            LastName = "Doe",
            Mobile = "555-0100",
            Street = "123 Elm St",
            City = "Springfield",
            PostalCode = "12345",
            Country = "USA",
            Created = DateTime.Now,
            Modified = DateTime.Now,
            CreatedBy = "Admin",
            ModifiedBy = "Admin",
            
            SecurityStamp = Guid.NewGuid().ToString()
        };
        
        adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
        adminUser.NormalizedEmail = adminUser.Email.ToUpper();
        adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, pwd);

        var ownerUser = new Member
        {
            Id = 2,
            UserName = "o@o.o",
            Email = "o@o.o",
            EmailConfirmed = true,
            FirstName = "Jane",
            LastName = "Smith",
            Mobile = "555-0200",
            Street = "456 Oak St",
            City = "Metropolis",
            PostalCode = "67890",
            Country = "USA",
            Created = DateTime.Now,
            Modified = DateTime.Now,
            CreatedBy = "Admin",
            ModifiedBy = "Admin",
            
            SecurityStamp = Guid.NewGuid().ToString()
        };
        
        ownerUser.NormalizedUserName = ownerUser.UserName.ToUpper();
        ownerUser.NormalizedEmail = ownerUser.Email.ToUpper();
        ownerUser.PasswordHash = passwordHasher.HashPassword(ownerUser, pwd);

        var passengerUser = new Member
        {
            Id = 3,
            UserName = "p@p.p",
            Email = "p@p.p",
            EmailConfirmed = true,
            FirstName = "Jim",
            LastName = "Bean",
            Mobile = "555-0300",
            Street = "789 Pine St",
            City = "Gotham",
            PostalCode = "10112",
            Country = "USA",
            Created = DateTime.Now,
            Modified = DateTime.Now,
            CreatedBy = "Admin",
            ModifiedBy = "Admin",
            
            SecurityStamp = Guid.NewGuid().ToString()
        };
        
        passengerUser.NormalizedUserName = passengerUser.UserName.ToUpper();
        passengerUser.NormalizedEmail = passengerUser.Email.ToUpper();
        passengerUser.PasswordHash = passwordHasher.HashPassword(passengerUser, pwd);
        
        
        
        
        
        
        
        
        
        
        
        

        List<Member> users = new List<Member>()
            {
                adminUser,
                ownerUser,
                passengerUser
            };

        builder.Entity<Member>().HasData(users);

        // Seed UserRoles
        List<IdentityUserRole<int>> userRoles = new List<IdentityUserRole<int>>();

        userRoles.Add(new IdentityUserRole<int>
        {
            UserId = users[0].Id,
            RoleId = roles.First(q => q.Name == "Admin").Id
        });

        userRoles.Add(new IdentityUserRole<int>
        {
            UserId = users[1].Id,
            RoleId = roles.First(q => q.Name == "Owner").Id
        });

        userRoles.Add(new IdentityUserRole<int>
        {
            UserId = users[2].Id,
            RoleId = roles.First(q => q.Name == "Passenger").Id
        });

        builder.Entity<IdentityUserRole<int>>().HasData(userRoles);
    }
}
