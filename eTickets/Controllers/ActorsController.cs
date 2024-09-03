using Azure;
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
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var actor = await _actorsRepository.GetActorById(id);
            if (actor == null)
            {
                return View(null);
            }
            var editActorRequest = new EditActorRequest
            {
                Id = actor.Id,
                FullName = actor.FullName,
                ProfilePictureURL = actor.ProfilePictureURL,
                Bio = actor.Bio
            };

            return View(editActorRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditActorRequest editActorRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(editActorRequest);
            }
            var actor = new Actor
            {
                Id = editActorRequest.Id,
                FullName = editActorRequest.FullName,
                Bio = editActorRequest.Bio,
                ProfilePictureURL = editActorRequest.ProfilePictureURL
            };
            var updatedActor = await _actorsRepository.UpdateAsync(actor);
            if (updatedActor != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit", new { id = editActorRequest.Id });

        }
        [HttpPost]
        public async Task<IActionResult> Delete(EditActorRequest editActorRequest)
        {
            var deletedActor = await _actorsRepository.DeleteAsync(editActorRequest.Id);
            if (deletedActor != null)
            {
                //Show Message Inidicating The Tag Has Been Deleted
                return RedirectToAction("Index");
            }
            //Show Message Inidicating The Tag Has Not Been Deleted
            return View("Edit", new { id = editActorRequest.Id });
        }
    }
}
