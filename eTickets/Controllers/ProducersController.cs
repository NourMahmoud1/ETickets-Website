using eTickets.Data;
using eTickets.Models.Domain;
using eTickets.Models.View;
using eTickets.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
		private readonly IProducersRepository _producersRepository;

		public ProducersController(IProducersRepository producersRepository)
        {
			_producersRepository = producersRepository;
		}
        public async Task<IActionResult> Index()
        {
            var allProducers = await _producersRepository.GetProducersAsync();
            return View(allProducers);
        }
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(AddProducerRequest addProducerRequest)
		{
			if (!ModelState.IsValid)
			{
				return View(addProducerRequest);
			}

			var producer = new Producer
			{
				FullName = addProducerRequest.FullName,
				ProfilePictureURL = addProducerRequest.ProfilePictureURL,
				Bio = addProducerRequest.Bio
			};

			await _producersRepository.AddAsync(producer);
			return RedirectToAction(nameof(Index));
		}

	}
}
