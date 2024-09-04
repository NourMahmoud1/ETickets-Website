using eTickets.Data;
using eTickets.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly AppDbContext context;

        public MoviesRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            //var result = await context.Movies.Include(a => a.ActorsMovies).ThenInclude(a => a.Actor)
            //    .Include(m => m.CinemasMovies)
            //    .ThenInclude(m => m.Cinema).ToListAsync();
            var result = await context.Movies.Include(m => m.CinemasMovies)
                .ThenInclude(m => m.Cinema).ToListAsync();
            return result;
        }
        public async Task AddAsync(Movie movie)
        {
            await context.Movies.AddAsync(movie);
            await context.SaveChangesAsync();
        }

        public Task<Movie?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieById(Guid id)
        {
            throw new NotImplementedException();
        }


        public Task<Movie?> UpdateAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Producer>> GetProducersAsync()
        {
            return await context.Producers.ToListAsync();
        }
    }
}
