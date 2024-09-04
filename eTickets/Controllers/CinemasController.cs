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
		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			var cinema = await _cinemasRepository.GetCinemaByIdAsync(id);
			if (cinema == null)
			{
				return View(null);
			}
			var editCinemaRequest = new EditCinemaRequest
			{
				Id = cinema.Id,
				Name = cinema.Name,
				Logo = cinema.Logo,
				Description = cinema.Description
			};
			return View(editCinemaRequest);
		}
        [HttpPost]
        public async Task<IActionResult> Edit(EditCinemaRequest editCinemaRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(editCinemaRequest);
            }
            var cinema = new Cinema
            {
                Id = editCinemaRequest.Id,
                Name = editCinemaRequest.Name,
                Description = editCinemaRequest.Description,
                Logo = editCinemaRequest.Logo
            };
            var updatedProducer = await _cinemasRepository.UpdateAsync(cinema);
            if (updatedProducer != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit", new { id = cinema.Id });

        }
        [HttpPost]
        public async Task<IActionResult> Delete(EditCinemaRequest editCinemaRequest)
        {
            var deletedProducer = await _cinemasRepository.DeleteAsync(editCinemaRequest.Id);
            if (deletedProducer != null)
            {
                return RedirectToAction("Index");
            }
            return View("Edit", new { id = editCinemaRequest.Id });
        }
    }
}
