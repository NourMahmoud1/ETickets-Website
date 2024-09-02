using eTickets.Models.Domain;

namespace eTickets.Repositories
{
	public interface ICinemasRepository
	{
		Task<IEnumerable<Cinema>> GetCinemasAsync();

		Task AddAsync(Cinema cinema);
		Task<Cinema> GetCinemaByIdAsync(Guid id);

	}
}
