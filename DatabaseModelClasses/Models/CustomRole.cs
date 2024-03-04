using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DatabaseModelClasses.Models;

public class CustomRole : IdentityRole<int>
{
  public CustomRole() : base() { }
  public CustomRole(string roleName) : base(roleName) { }
  public CustomRole(string roleName, string description,
    DateTime createdDate)
    : base(roleName)
  {
    base.Name = roleName;
    this.Description = description;
    this.CreatedDate = createdDate;
  }
  
  [Display(Name = "Role ID")]
  public override int Id { get; set; }
  
  [Display(Name = "Description for Role")]
  public string? Description { get; set; }

  [Display(Name = "Created Date")]
  public DateTime CreatedDate { get; set; }

}