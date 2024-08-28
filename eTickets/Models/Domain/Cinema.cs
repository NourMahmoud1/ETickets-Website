using System.ComponentModel.DataAnnotations;

namespace eTickets.Models.Domain
{
    public class Cinema
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Cinema Name")]
        public string Name { get; set; }
        [Display(Name = "Cinema Description")]
        public string Description { get; set; }
		[Display(Name = "Cinema Logo")]
        public string Logo { get; set; }
        //Relationships
        //movies
        public ICollection<Cinema_Movie> CinemasMovies { get; set; }
    }
}
