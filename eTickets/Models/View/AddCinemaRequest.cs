using System.ComponentModel.DataAnnotations;

namespace eTickets.Models.View
{
	public class AddCinemaRequest
	{
		[Display(Name = "Cinema Name")]
		[Required(ErrorMessage = "Cinema Name is required")]
		public string Name { get; set; }
		[Display(Name = "Cinema Description")]
		[Required(ErrorMessage = "Cinema Description is required")]
		public string Description { get; set; }
		[Display(Name = "Cinema Logo")]
		[Required(ErrorMessage = "Cinema Logo is required")]
		public string Logo { get; set; }
	}
}
