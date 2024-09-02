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

		public Task<Cinema> GetCinemaByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Cinema>> GetCinemasAsync()
		{
			var result = await context.Cinemas.ToListAsync();
			return result;
		}
	}
}
