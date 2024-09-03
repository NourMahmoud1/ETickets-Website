using System.ComponentModel.DataAnnotations;

namespace eTickets.Models.View
{
	public class EditProducerRequest
	{
		public Guid Id { get; set; }
		[Display(Name = "Full Name")]
		[Required(ErrorMessage = "Full Name is required")]
		public string FullName { get; set; }
		[Display(Name = "Profile Picture")]
		[Required(ErrorMessage = "Profile Picture is required")]
		public string ProfilePictureURL { get; set; }
		[Display(Name = "Biography")]
		[Required(ErrorMessage = "Biography is required")]
		public string Bio { get; set; }
	}
}
