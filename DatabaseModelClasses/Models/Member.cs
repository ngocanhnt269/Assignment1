using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DatabaseModelClasses.Models;

public class Member : IdentityUser<int>
{
    
    [Required]
    [StringLength(50)]
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [Required]
    [Phone]
    [StringLength(20)]
    public string? Mobile { get; set; }

    [Required]
    [StringLength(100)]
    public string? Street { get; set; }

    [Required]
    [StringLength(50)]
    public string? City { get; set; }

    [Required]
    [StringLength(20)]
    [Display(Name = "Postal Code")]
    public string? PostalCode { get; set; }

    [Required]
    [StringLength(50)]
    public string? Country { get; set; }
    
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }

    [Display(Name = "Created By")]
    public string? CreatedBy { get; set; }

    [Display(Name = "Modified By")]
    public string? ModifiedBy { get; set; }
}