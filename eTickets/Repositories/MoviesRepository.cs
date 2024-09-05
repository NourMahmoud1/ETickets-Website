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

		public async Task<Movie?> DeleteAsync(Guid id)
		{
			var existingMovie = await context.Movies.FindAsync(id);
			if (existingMovie != null)
			{
				context.Movies.Remove(existingMovie);
				await context.SaveChangesAsync();
				return existingMovie;
			}

			return null;
		}

		public async Task<Movie> GetMovieById(Guid id)
		{
			var result = await context.Movies.Include(p => p.Producer)
				.Include(a => a.ActorsMovies)
				.ThenInclude(a => a.Actor)
				.Include(m => m.CinemasMovies)
				.ThenInclude(m => m.Cinema)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (result == null)
			{
				return null;
			}
			//var result = await context.Movies.FirstOrDefaultAsync(x => x.Id == id);
			return result;
		}


		public async Task<Movie?> UpdateAsync(Movie movie)
		{
			var existingMovie = await context.Movies.Include(a => a.ActorsMovies)
				.ThenInclude(a => a.Actor)
				.Include(m => m.CinemasMovies)
				.ThenInclude(m => m.Cinema).FirstOrDefaultAsync(x => x.Id == movie.Id);
			if (existingMovie == null)
			{
				return null;
			}

			existingMovie.Name = movie.Name;
			existingMovie.Description = movie.Description;
			existingMovie.Price = movie.Price;
			existingMovie.ImageURL = movie.ImageURL;
			existingMovie.StartDate = movie.StartDate;
			existingMovie.EndDate = movie.EndDate;
			existingMovie.MovieCategory = movie.MovieCategory;
			existingMovie.ProducerId = movie.ProducerId;

			//// Clear existing actor mappings
			//existingMovie.ActorsMovies.Clear();

			// Map new actors
			foreach (var actorMovie in movie.ActorsMovies)
			{
				existingMovie.ActorsMovies.Add(actorMovie);
			}

			//// Clear existing cinema mappings
			//existingMovie.CinemasMovies.Clear();

			// Map new cinemas
			foreach (var cinemaMovie in movie.CinemasMovies)
			{
				existingMovie.CinemasMovies.Add(cinemaMovie);
			}

			await context.SaveChangesAsync();
			return existingMovie;

		}

		public async Task<IEnumerable<Producer>> GetProducersAsync()
		{
			return await context.Producers.ToListAsync();
		}

		public async Task<IEnumerable<Movie>> SearchMoviesAsync(string searchString)
		{
			var movies = await GetMoviesAsync();

			if (!string.IsNullOrEmpty(searchString))
			{
				movies = movies.Where(m => m.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
			}
			return movies;
		}
	}
}
