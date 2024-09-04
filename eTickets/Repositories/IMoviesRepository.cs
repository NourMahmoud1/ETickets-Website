using eTickets.Models.Domain;

namespace eTickets.Repositories
{
    public interface IMoviesRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieById(Guid id);
        //add Movieasinc
        Task AddAsync(Movie movie);
        //update Movie
        Task<Movie?> UpdateAsync(Movie movie);
        //delete Movie
        Task<Movie?> DeleteAsync(Guid id);
        Task<IEnumerable<Producer>> GetProducersAsync();

    }
}
