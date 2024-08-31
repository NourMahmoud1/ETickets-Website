namespace eTickets.Repositories
{
	public interface IImageRepository
	{
		Task<string> UploadAsync(IFormFile file);
	}
}
