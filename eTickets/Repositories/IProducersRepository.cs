using eTickets.Models.Domain;

namespace eTickets.Repositories
{
	public interface IProducersRepository
	{
		Task<IEnumerable<Producer>> GetProducersAsync();
		Task AddAsync(Producer producer);
		Task<Producer> GetProducerByIdAsync(Guid id);
        //update actor
        Task<Producer?> UpdateAsync(Producer producer);
        //delete actor
        Task<Producer?> DeleteAsync(Guid id);
    }
}
