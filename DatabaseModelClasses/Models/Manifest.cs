using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModelClasses.Models;

public class Manifest
{
    [Key]
    [Display(Name = "Manifest ID")]
    public int ManifestId { get; set; } // Primary key

    [Required]
    [Display(Name = "Member ID")]
    public int Id { get; set; } // Foreign key to Member

    [Required]
    [Display(Name = "Trip ID")]
    public int TripId { get; set; } // Foreign key to Trip

    public string? Notes { get; set; }

    // Navigation properties
    [ForeignKey("Id")]
    public virtual Member? Member { get; set; }

    [ForeignKey("TripId")]
    public virtual Trip? Trip { get; set; }

    // System-managed fields
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }

    [Display(Name = "Created By")]
    public string? CreatedBy { get; set; }

    [Display(Name = "Modified By")]
    public string? ModifiedBy { get; set; }
}