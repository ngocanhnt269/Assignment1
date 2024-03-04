
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace DatabaseModelClasses.ViewModels
{
    public class MemberViewModel
    {
        // This is used for identification, it is not editable
        [Display(Name = "Member ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

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
        [DisplayName("Postal Code")]
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
}
