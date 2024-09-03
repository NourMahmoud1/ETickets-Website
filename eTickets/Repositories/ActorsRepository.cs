using Azure;
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
		//get all actors
		public async Task<IEnumerable<Actor>> GetActorsAsync()
		{
			var result = await _context.Actors.ToListAsync();
			return result;
		}
		//find actor by id
		public async Task<Actor> GetActorById(Guid id)
		{
			var result = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
			return result;
		}
		//add actor
		public async Task AddAsync(Actor actor)
		{
			await _context.Actors.AddAsync(actor);
			await _context.SaveChangesAsync();
			
		}

        public async Task<Actor?> UpdateAsync(Actor actor)
        {
            var existingactor = await _context.Actors.FindAsync(actor.Id);
            if (existingactor != null)
            {
                existingactor.FullName = actor.FullName;
                existingactor.Bio = actor.Bio;
                existingactor.ProfilePictureURL = actor.ProfilePictureURL;
                await _context.SaveChangesAsync();
                return existingactor;
            }
            return null;
        }

        public async Task<Actor?> DeleteAsync(Guid id)
        {
            var existingActor = await _context.Actors.FindAsync(id);
            if (existingActor != null)
            {
                _context.Actors.Remove(existingActor);
                await _context.SaveChangesAsync();
                return existingActor;
            }
            return null;
        }
    }
}
