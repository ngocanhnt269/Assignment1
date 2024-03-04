using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModelClasses.Models;

public class Vehicle
{
    [Key]
    [Display(Name = "Vehicle ID")]
    public int VehicleId { get; set; }

    [Required]
    [StringLength(100)]
    public string? Model { get; set; }

    [Required]
    [StringLength(100)]
    public string? Make { get; set; }

    [Required]
    [Range(1900, 2100)] // Validation range set to 1990-2100
    public int Year { get; set; }

    [Required]
    [Display(Name = "Number of Seats")]
    [Range(1, 20)] // Validation range set to 1-20
    public int NumberOfSeats { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Vehicle Type")]
    public string? VehicleType { get; set; }

    // Foreign key to Member
    [Required]
    [ForeignKey("Member")]
    [Display(Name = "Member ID")]
    public int Id { get; set; }
    public Member? Member { get; set; } // Navigation property

    // System-managed fields
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    
    [Display(Name = "Created By")]
    public string? CreatedBy { get; set; }

    [Display(Name = "Modified By")]
    public string? ModifiedBy { get; set; }
}