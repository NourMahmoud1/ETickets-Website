namespace eTickets.Models.Domain
{
    public class Actor_Movie
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
