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

		public async Task<Producer> GetProducerByIdAsync(Guid id)
		{
            var result = await context.Producers.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Producer?> UpdateAsync(Producer producer)
        {
            var existingactor = await context.Producers.FindAsync(producer.Id);
            if (existingactor != null)
            {
                existingactor.FullName = producer.FullName;
                existingactor.Bio = producer.Bio;
                existingactor.ProfilePictureURL = producer.ProfilePictureURL;
                await context.SaveChangesAsync();
                return existingactor;
            }
            return null;
        }

        public async Task<Producer?> DeleteAsync(Guid id)
        {
            var existingProducer = await context.Producers.FindAsync(id);
            if (existingProducer != null)
            {
                context.Producers.Remove(existingProducer);
                await context.SaveChangesAsync();
                return existingProducer;
            }
            return null;
        }
    }
}
