using System.ComponentModel.DataAnnotations;

namespace eTickets.Models.Domain
{
    public class Actor
    {

        [Key]
        public Guid Id {  get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }
        //Relationships
        public ICollection<Actor_Movie> ActorsMovies { get; set; }

    }
}
