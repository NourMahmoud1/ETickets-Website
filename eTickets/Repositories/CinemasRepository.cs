using eTickets.Data;
using eTickets.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Repositories
{
	public class CinemasRepository : ICinemasRepository
	{
		private readonly AppDbContext context;

		public CinemasRepository(AppDbContext context)
        {
			this.context = context;
		}

		public async Task AddAsync(Cinema cinema)
		{
			await context.Cinemas.AddAsync(cinema);
			await context.SaveChangesAsync();
		}

		public async Task<Cinema?> DeleteAsync(Guid id)
		{
			var existingCinema = await context.Cinemas.FindAsync(id);
			if (existingCinema != null)
			{
				context.Cinemas.Remove(existingCinema);
				await context.SaveChangesAsync();
				return existingCinema;
			}
			return null;
		}

		public async Task<Cinema> GetCinemaByIdAsync(Guid id)
		{
			var result = await context.Cinemas.FirstOrDefaultAsync(x => x.Id == id);
			return result;
		}

		public async Task<IEnumerable<Cinema>> GetCinemasAsync()
		{
			var result = await context.Cinemas.ToListAsync();
			return result;
		}

		public async Task<Cinema?> UpdateAsync(Cinema cinema)
		{
			var existingCinema = await context.Cinemas.FindAsync(cinema.Id);
			if (existingCinema != null)
			{
				existingCinema.Name = cinema.Name;
				existingCinema.Description = cinema.Description;
				existingCinema.Logo = cinema.Logo;
				await context.SaveChangesAsync();
				return existingCinema;
			}
			return null;
		}
	}
}
