using eTickets.Models.Domain;

namespace eTickets.Repositories
{
	public interface IProducersRepository
	{
		Task<IEnumerable<Producer>> GetProducersAsync();
		Task AddAsync(Producer producer);
		Task<Producer> GetProducerByIdAsync(Guid id);
        //update Producer
        Task<Producer?> UpdateAsync(Producer producer);
        //delete producer
        Task<Producer?> DeleteAsync(Guid id);
    }
}
