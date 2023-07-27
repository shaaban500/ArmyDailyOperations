using DailyOperations.Domain.Interfaces.Services;
using DailyOperations.Domain.Interfaces.Services.Members;
using DailyOperations.Domain.ViewModels.PoliceAssistants;
using Microsoft.AspNetCore.Mvc;

namespace DailyOperations.Api.Controllers.Members
{
    public class PoliceAssistantsController : Controller
    {
        private readonly IPowerTypesService _powerTypesService;
        private readonly IDepartmentServices _departmentServices;
        private readonly IpoliceAssistantsService _policeAssistantsService;
        private readonly IAssistantsMilitaryDegreesService _assistantsMilitaryDegreesService;

        public PoliceAssistantsController(
            IpoliceAssistantsService policeAssistantsService,
            IAssistantsMilitaryDegreesService assistantsMilitaryDegreesService,
            IPowerTypesService powerTypesService,
            IDepartmentServices departmentServices)
        {
            _policeAssistantsService = policeAssistantsService;
            _assistantsMilitaryDegreesService = assistantsMilitaryDegreesService;
            _powerTypesService = powerTypesService;
            _departmentServices = departmentServices;
        }



        public async Task<IActionResult> GetAll()
        {
            var policeAssistants = await _policeAssistantsService.GetAll();

            var policeOficersViewModel = new GetAllPoliceAssistantViewModel
            {
                policeAssistants = policeAssistants.ToList(),
                AssistantsMilitaryDegrees = await _assistantsMilitaryDegreesService.GetAll(),
                PowerTypes = await _powerTypesService.GetAll(),
                Departments = await _departmentServices.GetAll()
            };

            return View(policeOficersViewModel);
        }

        public async Task<IActionResult> AddOrUpdate(GetAllPoliceAssistantViewModel model)
        {
            await _policeAssistantsService.AddOrUpdate(model.PoliceAssistant);

            return RedirectToAction(nameof(GetAll));
        }

        public async Task<IActionResult> Delete(long id)
        {
            await _policeAssistantsService.Delete(id);

            return RedirectToAction(nameof(GetAll));
        }
    }
}
