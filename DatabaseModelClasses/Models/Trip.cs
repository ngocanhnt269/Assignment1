using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModelClasses.Models;

public class Trip
{
    [Key]
    [Display(Name = "Trip ID")]
    public int TripId { get; set; } // Primary key

    [Required]
    [Display(Name = "Vehicle ID")]
    public int VehicleId { get; set; } // Foreign key to Vehicle

    [Column(TypeName = "Date")]
    public DateTime Date { get; set; }

    [Column(TypeName = "Time")]
    [DataType(DataType.Time)]
    public DateTime Time { get; set; }

    [Required]
    [StringLength(255)]
    [Display(Name = "Destination Address")]
    public string? DestinationAddress { get; set; }

    [Required]
    [StringLength(255)]
    [Display(Name = "Meeting Address")]
    public string? MeetingAddress { get; set; }

    // Navigation property for Vehicle
    [ForeignKey("VehicleId")]
    [Display(Name = "Vehicle ID")]
    public virtual Vehicle? Vehicle { get; set; }

    // System-managed fields
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }

    [Display(Name = "Created By")]
    public string? CreatedBy { get; set; }

    [Display(Name = "Modified By")]
    public string? ModifiedBy { get; set; }
}