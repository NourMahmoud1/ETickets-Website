using eTickets.Models.Domain;

namespace eTickets.Repositories
{
	public interface IProducersRepository
	{
		Task<IEnumerable<Producer>> GetProducersAsync();
		Task AddAsync(Producer producer);
		Task<Producer> GetProducerByIdAsync(Guid id);
	}
}
