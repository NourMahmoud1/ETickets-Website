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
		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			var producer = await _producersRepository.GetProducerByIdAsync(id);
			if (producer == null)
			{
				return View(null);
			}
			var editProducerRequest = new EditProducerRequest
			{
				Id = producer.Id,
				FullName = producer.FullName,
				ProfilePictureURL = producer.ProfilePictureURL,
				Bio = producer.Bio
			};
			return View(editProducerRequest);
		}
        [HttpPost]
        public async Task<IActionResult> Edit(EditProducerRequest editProducerRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(editProducerRequest);
            }
            var producer = new Producer
            {
                Id = editProducerRequest.Id,
                FullName = editProducerRequest.FullName,
                Bio = editProducerRequest.Bio,
                ProfilePictureURL = editProducerRequest.ProfilePictureURL
            };
            var updatedProducer = await _producersRepository.UpdateAsync(producer);
            if (updatedProducer != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit", new { id = editProducerRequest.Id });

        }
        [HttpPost]
        public async Task<IActionResult> Delete(EditProducerRequest editProducerRequest)
        {
            var deletedProducer = await _producersRepository.DeleteAsync(editProducerRequest.Id);
            if (deletedProducer != null)
            {
                //Show Message Inidicating The Tag Has Been Deleted
                return RedirectToAction("Index");
            }
            //Show Message Inidicating The Tag Has Not Been Deleted
            return View("Edit", new { id = editProducerRequest.Id });
        }
    }
}
