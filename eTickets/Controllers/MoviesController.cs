using eTickets.Data;
using eTickets.Data.Enums;
using eTickets.Models.Domain;
using eTickets.Models.View;
using eTickets.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesRepository moviesRepository;
        private readonly IActorsRepository actorsRepository;
        private readonly ICinemasRepository cinemasRepository;

        public MoviesController(IMoviesRepository moviesRepository, IActorsRepository actorsRepository, ICinemasRepository cinemasRepository)
        {
            this.moviesRepository = moviesRepository;
            this.actorsRepository = actorsRepository;
            this.cinemasRepository = cinemasRepository;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await moviesRepository.GetMoviesAsync();
            return View(movies);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var cinemas = await cinemasRepository.GetCinemasAsync();
            var actors = await actorsRepository.GetActorsAsync();
            var producers = await moviesRepository.GetProducersAsync();
            var model = new AddMovieRequest
            {
                Categories = Enum.GetValues(typeof(MovieCategory))
                             .Cast<MovieCategory>()
                             .Select(c => new SelectListItem
                             {
                                 Value = ((int)c).ToString(),
                                 Text = c.ToString()
                             }),
                Producers = producers.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.FullName
                }),
                Actors = actors.Select(x => new SelectListItem { Text = x.FullName, Value = x.Id.ToString() }),
                Cinemas = cinemas.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddMovieRequest addMovieRequest)
        {
           
            var movie = new Movie
            {
                Name = addMovieRequest.Name,
                Description = addMovieRequest.Description,
                Price = addMovieRequest.Price,
                ImageURL = addMovieRequest.ImageURL,
                MovieCategory = addMovieRequest.MovieCategory,
                StartDate = addMovieRequest.StartDate,
                EndDate = addMovieRequest.EndDate,
                ProducerId = Guid.Parse(addMovieRequest.SelectedProducer)
            };
            // actors, cinemas
            //Map actor
            movie.ActorsMovies = new List<Actor_Movie>();
            foreach (var selectedActorId in addMovieRequest.SelectedActors)
            {
                var selectedActorIdAsGuid = Guid.Parse(selectedActorId);
                movie.ActorsMovies.Add(new Actor_Movie
                {
                    ActorId = selectedActorIdAsGuid,
                    MovieId = movie.Id
                });
            }
            //Map Cinema
            movie.CinemasMovies = new List<Cinema_Movie>();
            foreach (var selectedCinemaId in addMovieRequest.SelectedCinemas)
            {
                var selectedCinemaIdAsGuid = Guid.Parse(selectedCinemaId);
                movie.CinemasMovies.Add(new Cinema_Movie
                {
                    CinemaId = selectedCinemaIdAsGuid,
                    MovieId = movie.Id
                });
            }
			if (!ModelState.IsValid)
			{
				return View(addMovieRequest);
			}
			await moviesRepository.AddAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
