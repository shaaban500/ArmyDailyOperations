using DailyOperations.Domain.Interfaces.Services.Members;
using DailyOperations.Domain.ViewModels.PoliceAssistants;
using Microsoft.AspNetCore.Mvc;

namespace DailyOperations.Api.Controllers.Members
{
    public class AssistantMilitaryDegreesController : Controller
    {
        private readonly IAssistantsMilitaryDegreesService _assistantsMilitaryDegreesService;

        public AssistantMilitaryDegreesController(IAssistantsMilitaryDegreesService assistantsMilitaryDegreesService)
        {
            _assistantsMilitaryDegreesService = assistantsMilitaryDegreesService;
        }

        public async Task<IActionResult> GetAll()
        {
            var assistantsMilitaryDegrees = await _assistantsMilitaryDegreesService.GetAll();
            return View(assistantsMilitaryDegrees);
        }

        public async Task<IActionResult> AddOrUpdate(GetAllPoliceAssistantViewModel model)
        {
            await _assistantsMilitaryDegreesService.AddOrUpdate(model.AssistantMililaryDegree);

            return RedirectToAction("GetAll", "PoliceAssistants");
        }

        public async Task<IActionResult> Delete(long id)
        {
            await _assistantsMilitaryDegreesService.Delete(id);

            return RedirectToAction(nameof(GetAll));
        }
    }
}
