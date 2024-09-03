using System.ComponentModel.DataAnnotations;

namespace eTickets.Models.View
{
	public class EditActorRequest
	{
		public Guid Id { get; set; }
		[Required(ErrorMessage = "Name is Required")]
		[StringLength(100, MinimumLength = 2, ErrorMessage = "Full Name must be between 2 and 100 characters.")]
		public string FullName { get; set; }
		[Required(ErrorMessage = "Profile Picture is Required")]

		public string ProfilePictureURL { get; set; }
		[Required(ErrorMessage = "Bio is Required")]
		[StringLength(1000, MinimumLength = 10, ErrorMessage = "Bio must be between 10 and 1000 characters.")]
		public string Bio { get; set; }

	}
}
