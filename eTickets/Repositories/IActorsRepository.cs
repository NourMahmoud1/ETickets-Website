using Azure;
using eTickets.Models.Domain;

namespace eTickets.Repositories
{
	public interface IActorsRepository
	{
		Task<IEnumerable<Actor>> GetActorsAsync();
		Task<Actor> GetActorById(Guid id);
		//add actorasinc
		Task AddAsync(Actor actor);
        //update actor
        Task<Actor?> UpdateAsync(Actor actor);
        //delete actor
        Task<Actor?> DeleteAsync(Guid id);
	}
}
