using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models.Domain
{
    public class Producer
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }
		[Display(Name = "Biography")]
        public string Bio { get; set; }
        //Relationships
        [ForeignKey("MovieId")]
        public Guid MovieId { get; set; }
        public ICollection<Movie> Movies { get; set; }


    }
}
