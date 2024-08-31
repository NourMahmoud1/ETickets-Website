using eTickets.Models.Domain;

namespace eTickets.Repositories
{
	public interface IActorsRepository
	{
		Task<IEnumerable<Actor>> GetActorsAsync();
		Actor GetActorById(int id);
		//add actorasinc
		Task AddAsync(Actor actor);

	}
}
