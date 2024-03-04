using System.ComponentModel.DataAnnotations;

namespace DatabaseModelClasses.ViewModels
{
	public class ManifestViewModel
	{
		[Required]
		[Display(Name = "Manifest ID")]
		public int ManifestId { get; set; }

		[Required]
		[Display(Name = "Member ID")]
		public int Id { get; set; }

		[Required]
		[Display(Name = "Trip ID")]
		public int TripId { get; set; }

		public string? Notes { get; set; }
		
		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
		public string? CreatedBy { get; set; }
		public string? ModifiedBy { get; set; }

	}
}
