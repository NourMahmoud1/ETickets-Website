using eTickets.Data;
using eTickets.Models.Domain;
using eTickets.Models.View;
using eTickets.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
		private readonly ICinemasRepository _cinemasRepository;

		public CinemasController(ICinemasRepository cinemasRepository)
        {
			_cinemasRepository = cinemasRepository;
		}
        public async Task<IActionResult> Index()
        {
            var cinemas = await _cinemasRepository.GetCinemasAsync();
            return View(cinemas);
        }
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(AddCinemaRequest addCinemaRequest)
		{
			if (!ModelState.IsValid)
			{
				return View(addCinemaRequest);
			}

			var cinema = new Cinema
			{
				Name = addCinemaRequest.Name,
				Logo = addCinemaRequest.Logo,
				Description = addCinemaRequest.Description
			};

			await _cinemasRepository.AddAsync(cinema);
			return RedirectToAction(nameof(Index));
		}
	}
}
