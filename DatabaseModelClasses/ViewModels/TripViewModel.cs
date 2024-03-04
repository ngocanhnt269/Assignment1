using System.ComponentModel.DataAnnotations;

namespace DatabaseModelClasses.ViewModels
{
    public class TripViewModel
    {
		// This is used for identification, it is not editable by the user directly	    
        [Display(Name = "Trip ID")]
        public int TripId { get; set; }

        [Required]
        [Display(Name = "Vehicle ID")]
        public int VehicleId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

		[Required]
		[DataType(DataType.Time)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:h:mm tt}")]
		public DateTime Time { get; set; }


		[Required]
        [StringLength(255)]
        [Display(Name = "Destination Address")]
        public string? DestinationAddress { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Meeting Address")]
        public string? MeetingAddress { get; set; }
        
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        
        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; }
        
        [Display(Name = "Modified By")]
        public string? ModifiedBy { get; set; }

	}
}
