using DailyOperations.Domain.Interfaces.Services.Members;
using DailyOperations.Domain.ViewModels.PoliceAssistants;
using DailyOperations.Domain.ViewModels.PoliceOfficers;
using Microsoft.AspNetCore.Mvc;

namespace DailyOperations.Api.Controllers
{
    public class PowerTypesController : Controller
    {
        private readonly IPowerTypesService _powerTypesService;
        public PowerTypesController(IPowerTypesService powerTypesService)
        {
            _powerTypesService = powerTypesService;
        }

        public async Task<IActionResult> GetAll()
        {
            var powerTypes = await _powerTypesService.GetAll();
            return View(powerTypes);
        }

        public async Task<IActionResult> AddOrUpdate(GetAllPoliceOfficersViewModel model)
        {
            await _powerTypesService.AddOrUpdate(model.PowerType);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(long id)
        {
            await _powerTypesService.Delete(id);

            return RedirectToAction(nameof(GetAll));
        }
    }
}
