using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models.Domain
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }
		[Display(Name = " Name")]
		[Required(ErrorMessage = "Name is Required")]
		[StringLength(100, MinimumLength = 2, ErrorMessage = " Name must be between 2 and 100 characters.")]

		public string Name { get; set; }
        [Required(ErrorMessage = "Description is Required")]

        public string Description { get; set; }
        [Required(ErrorMessage = "Price is Required")]
        public double Price { get; set; }
        public string? PosterURL { get; set; }
        [Required(ErrorMessage = "Picture is Required")]
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Start Date is Required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End Date is Required")]
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
        //Relationships
        public ICollection<Actor_Movie> ActorsMovies { get; set; }
        //producer
        [ForeignKey("ProducerId")]
        public Guid ProducerId { get; set; }
        public Producer Producer { get; set; }
        //cinema
        public ICollection<Cinema_Movie> CinemasMovies { get; set; }
        
    }
}
