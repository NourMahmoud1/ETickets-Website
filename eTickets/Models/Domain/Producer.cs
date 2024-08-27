using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models.Domain
{
    public class Producer
    {
        [Key]
        public Guid Id { get; set; }

        public string FullName { get; set; }
        public string ProfilePictureURL { get; set; }
        public string Bio { get; set; }
        //Relationships
        [ForeignKey("MovieId")]
        public Guid MovieId { get; set; }
        public ICollection<Movie> Movies { get; set; }


    }
}
