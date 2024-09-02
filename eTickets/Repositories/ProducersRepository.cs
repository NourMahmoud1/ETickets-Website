using eTickets.Data;
using eTickets.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Repositories
{
	public class ProducersRepository : IProducersRepository
	{
		private readonly AppDbContext context;

		public ProducersRepository(AppDbContext context)
        {
			this.context = context;
		}
        public async Task<IEnumerable<Producer>> GetProducersAsync()
		{
			var result = await context.Producers.ToListAsync();
			return result;
		}

		public async Task AddAsync(Producer producer)
		{
			await context.Producers.AddAsync(producer);
			await context.SaveChangesAsync();
		}

		public Task<Producer> GetProducerByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

	}
}
