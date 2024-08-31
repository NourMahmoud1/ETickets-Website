using eTickets.Data;
using eTickets.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Repositories
{
	public class ActorsRepository : IActorsRepository
	{
		private readonly AppDbContext _context;
		public ActorsRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Actor>> GetActorsAsync()
		{
			var result = await _context.Actors.ToListAsync();
			return result;
		}
		public Actor GetActorById(int id)
		{
			throw new NotImplementedException();
		}

		public async Task AddAsync(Actor actor)
		{
			await _context.Actors.AddAsync(actor);
			await _context.SaveChangesAsync();
			
		}
	}
}
