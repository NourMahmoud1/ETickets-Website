namespace eTickets.Models.Domain
{
    public class Cinema_Movie
    {
        public Guid Id { get; set; }
        public Guid CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

    }
}
