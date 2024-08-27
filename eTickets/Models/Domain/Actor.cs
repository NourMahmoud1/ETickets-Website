using System.ComponentModel.DataAnnotations;

namespace eTickets.Models.Domain
{
    public class Actor
    {

        [Key]
        public Guid Id {  get; set; }

        public string FullName { get; set; }
        public string ProfilePictureURL { get; set; }
        public string Bio { get; set; }
        //Relationships
        public ICollection<Actor_Movie> ActorsMovies { get; set; }

    }
}
