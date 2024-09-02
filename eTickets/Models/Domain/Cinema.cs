using System.ComponentModel.DataAnnotations;

namespace eTickets.Models.Domain
{
    public class Cinema
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Cinema Name")]
		[Required(ErrorMessage = "Cinema Name is required")]
        public string Name { get; set; }
        [Display(Name = "Cinema Description")]
        [Required(ErrorMessage = "Cinema Description is required")]
        public string Description { get; set; }
		[Display(Name = "Cinema Logo")]
        [Required(ErrorMessage = "Cinema Logo is required")]
        public string Logo { get; set; }
        //Relationships
        //movies
        public ICollection<Cinema_Movie> CinemasMovies { get; set; }
    }
}
