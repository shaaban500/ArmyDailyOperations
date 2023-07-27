using DailyOperations.Domain.Interfaces.Services;
using DailyOperations.Domain.ViewModels.PoliceOfficers;
using Microsoft.AspNetCore.Mvc;

namespace DailyOperations.Api.Controllers.Members
{
    public class OfficerMilitaryDegreesController : Controller
    {
        private readonly IOfficersMilitaryDegreesService _officersMilitaryDegreesService;
        public OfficerMilitaryDegreesController(IOfficersMilitaryDegreesService officersMilitaryDegreesService)
        {
            _officersMilitaryDegreesService = officersMilitaryDegreesService;
        }

        public async Task<IActionResult> GetAll()
        {
            var officerMilitaryDegrees = await _officersMilitaryDegreesService.GetAll();
            return View(officerMilitaryDegrees);
        }

        public async Task<IActionResult> AddOrUpdate(GetAllPoliceOfficersViewModel model)
        {
            await _officersMilitaryDegreesService.AddOrUpdate(model.OfficerMililaryDegree);

            return RedirectToAction("GetAll", "PoliceOfficers");
        }

        public async Task<IActionResult> Delete(long id)
        {
            await _officersMilitaryDegreesService.Delete(id);

            return RedirectToAction(nameof(GetAll));
        }
    }
}
