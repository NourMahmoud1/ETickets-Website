using eTickets.Data;
using eTickets.Models.Domain;
using eTickets.Models.View;
using eTickets.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
	public class ActorsController : Controller
	{
		private readonly IActorsRepository _actorsRepository;
		public ActorsController(IActorsRepository actorsRepository)
		{
			_actorsRepository = actorsRepository;
		}

		public async Task<IActionResult> Index()
		{
			var actors = await _actorsRepository.GetActorsAsync();
			return View(actors);
		}
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(AddActorRequest addActorRequest)
		{
			if (!ModelState.IsValid)
			{
				return View(addActorRequest);
			}

			var actor = new Actor
			{
				FullName = addActorRequest.FullName,
				ProfilePictureURL = addActorRequest.ProfilePictureURL,
				Bio = addActorRequest.Bio
			};

			await _actorsRepository.AddAsync(actor);
			return RedirectToAction(nameof(Index));
		}
	}
}
