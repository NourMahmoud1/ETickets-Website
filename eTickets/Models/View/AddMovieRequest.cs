using eTickets.Data.Enums;
using eTickets.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eTickets.Models.View
{
	public class AddMovieRequest
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public string? PosterURL { get; set; }
		public string ImageURL { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public MovieCategory MovieCategory { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        // Display producers
        public IEnumerable<SelectListItem> Producers { get; set; }
        // Collect selected producer
        public string SelectedProducer { get; set; }


        //Display actors
        public IEnumerable<SelectListItem> Actors { get; set; }
        //Collect actors
        public string[] SelectedActors { get; set; } = Array.Empty<string>();
        //Display cinema
        public IEnumerable<SelectListItem> Cinemas { get; set; }
        //Collect cinema
        public string[] SelectedCinemas { get; set; } = Array.Empty<string>();
    }
}
