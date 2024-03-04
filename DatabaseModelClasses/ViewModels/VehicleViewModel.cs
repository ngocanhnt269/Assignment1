using System.ComponentModel.DataAnnotations;

namespace DatabaseModelClasses.ViewModels
{
    public class VehicleViewModel
    {
        // This is used for identification, it is not editable by the user directly
        [Display(Name = "Vehicle ID")]
        public int VehicleId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Model { get; set; }

        [Required]
        [StringLength(100)]
        public string? Make { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Number of Seats")]
        [Range(1, 20)]
        public int NumberOfSeats { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Vehicle Type")]
        public string? VehicleType { get; set; }

        // Foreign key to Member
        [Required]
        [Display(Name = "Member ID")]
        public int Id { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Modified By")]
        public string? ModifiedBy { get; set; }
    }
}
