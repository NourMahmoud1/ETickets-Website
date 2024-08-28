using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movies.Include(m => m.CinemasMovies)
                .ThenInclude(m => m.Cinema).ToListAsync();
            return View(movies);
        }
    }
}
