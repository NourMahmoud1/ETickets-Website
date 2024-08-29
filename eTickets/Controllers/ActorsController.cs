using eTickets.Data;
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
    }
}
