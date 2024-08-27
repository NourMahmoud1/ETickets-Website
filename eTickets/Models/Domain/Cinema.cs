using System.ComponentModel.DataAnnotations;

namespace eTickets.Models.Domain
{
    public class Cinema
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        //Relationships
        //movies
        public ICollection<Cinema_Movie> CinemasMovies { get; set; }
    }
}
