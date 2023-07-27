using DailyOperations.Domain.Interfaces.Services;
using DailyOperations.Domain.Interfaces.Services.Members;
using DailyOperations.Domain.ViewModels.Soldiers;
using Microsoft.AspNetCore.Mvc;

namespace DailyOperations.Api.Controllers.Members
{
    public class SoldiersController : Controller
    {
        private readonly IPowerTypesService _powerTypesService;
        private readonly IDepartmentServices _departmentServices;
        private readonly IEducationTypesService _educationTypesService;
        private readonly IsoldiersService _soldiersService;
        public SoldiersController(
            IEducationTypesService educationTypesService,
            IPowerTypesService powerTypesService,
            IDepartmentServices departmentServices,
            IsoldiersService soldiersService)
        {
            _educationTypesService = educationTypesService;
            _powerTypesService = powerTypesService;
            _departmentServices = departmentServices;
            _soldiersService = soldiersService;
        }

        public async Task<IActionResult> GetAll()
        {
            var educationTypes = await _educationTypesService.GetAll();
            var powerTypes = await _powerTypesService.GetAll();
            var departments = await _departmentServices.GetAll();
            var soldiers = await _soldiersService.GetAll();

            var getAllSoldiersViewModel = new GetAllSoldiersViewModel
            {
                EducationTypes = educationTypes,
                PowerTypes = powerTypes,
                Departments = departments,
                Soldiers = soldiers
            };


            if (getAllSoldiersViewModel.Skills is not null)
            {
                foreach (var type in getAllSoldiersViewModel.Skills)
                {
                    getAllSoldiersViewModel.HasSkill.Add(false);
                }
            }

            return View(getAllSoldiersViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddorUpdate(GetAllSoldiersViewModel model)
        {
            await _soldiersService.AddOrUpdate(model.Soldier, model.CertificateName, model.ExtraDuration, model.HasSkill);
            return RedirectToAction(nameof(GetAll));
        }

        public async Task<IActionResult> Delete(long id)
        {
            await _soldiersService.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }

    }
}
