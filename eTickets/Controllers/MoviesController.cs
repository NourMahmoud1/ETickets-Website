using eTickets.Data;
using eTickets.Data.Enums;
using eTickets.Models.Domain;
using eTickets.Models.View;
using eTickets.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

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
		[HttpPost]
		public async Task<IActionResult> Index(string searchString)
		{
			var movies = await moviesRepository.SearchMoviesAsync(searchString);
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
		[HttpGet]
		public async Task<IActionResult> Details(Guid id)
		{
			var movie = await moviesRepository.GetMovieById(id);
			if (movie == null)
			{
				return View(null);
			}
			return View(movie);
		}
		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			var movie = await moviesRepository.GetMovieById(id);
			var actors = await actorsRepository.GetActorsAsync();
			var producers = await moviesRepository.GetProducersAsync();
			var cinemas = await cinemasRepository.GetCinemasAsync();

			if (movie != null)
			{
				var editMovieRequest = new EditMovieRequest
				{
					Id = movie.Id,
					Name = movie.Name,
					ImageURL = movie.ImageURL,
					Description = movie.Description,
					Price = movie.Price,
					StartDate = movie.StartDate,
					EndDate = movie.EndDate,
					MovieCategory = movie.MovieCategory,
					Categories = Enum.GetValues(typeof(MovieCategory))
							 .Cast<MovieCategory>()
							 .Select(c => new SelectListItem
							 {
								 Value = ((int)c).ToString(),
								 Text = c.ToString()
							 }),
					Actors = actors.Select(x => new SelectListItem
					{
						Text = x.FullName,
						Value = x.Id.ToString()
					}),
					SelectedActors = movie.ActorsMovies.Select(x => x.ActorId.ToString()).ToArray(),
					Cinemas = cinemas.Select(x => new SelectListItem
					{
						Text = x.Name,
						Value = x.Id.ToString(),
					}),
					SelectedCinemas = movie.CinemasMovies.Select(x => x.CinemaId.ToString()).ToArray(),
					Producers = producers.Select(x => new SelectListItem
					{
						Text = x.FullName,
						Value = x.Id.ToString(),
					}),
					SelectedProducer = movie.Producer.Id.ToString(),
				};
				return View(editMovieRequest);

			}
			return View(null);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(EditMovieRequest editMovieRequest)
		{
			

			var movie = await moviesRepository.GetMovieById(editMovieRequest.Id);
			if (movie == null)
			{
				return View(null);
			}
			//mapping view model to domain model

			movie.Id = editMovieRequest.Id;
			movie.Name = editMovieRequest.Name;
			movie.Description = editMovieRequest.Description;
			movie.Price = editMovieRequest.Price;
			movie.StartDate = editMovieRequest.StartDate;
			movie.EndDate = editMovieRequest.EndDate;
			movie.MovieCategory = editMovieRequest.MovieCategory;
			movie.ImageURL = editMovieRequest.ImageURL;
			movie.ProducerId = Guid.Parse(editMovieRequest.SelectedProducer);

			// Clear existing actor mappings
			movie.ActorsMovies.Clear();
			// Map new actors
			foreach (var selectedActorId in editMovieRequest.SelectedActors)
			{
				if (Guid.TryParse(selectedActorId, out var actorId))
				{
					movie.ActorsMovies.Add(new Actor_Movie
					{
						ActorId = actorId,
						MovieId = movie.Id
					});
				}
			}

			// Clear existing cinema mappings
			movie.CinemasMovies.Clear();

			// Map new cinemas
			foreach (var selectedCinemaId in editMovieRequest.SelectedCinemas)
			{
				if (Guid.TryParse(selectedCinemaId, out var cinemaId))
				{
					movie.CinemasMovies.Add(new Cinema_Movie
					{
						CinemaId = cinemaId,
						MovieId = movie.Id
					});
				}
			}
			//if (!ModelState.IsValid)
			//{
			//	return View(editMovieRequest);
			//}
			await moviesRepository.UpdateAsync(movie);
			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> Delete(EditMovieRequest editMovieRequest)
		{
			var deletedBlogPost = await moviesRepository.DeleteAsync(editMovieRequest.Id);
			if (deletedBlogPost != null)
			{
				return RedirectToAction("Index");
			}
			return View("Edit", new { id = editMovieRequest.Id });
		}
	}
}
