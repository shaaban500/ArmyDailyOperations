using DailyOperations.Domain.Interfaces.Services;
using DailyOperations.Domain.Interfaces.Services.Members;
using DailyOperations.Domain.ViewModels.PoliceOfficers;
using Microsoft.AspNetCore.Mvc;

namespace DailyOperations.Api.Controllers.Members
{
    public class PoliceOfficersController : Controller
    {
        private readonly IPoliceOfficersService _policeOfficersService;
        private readonly IOfficersMilitaryDegreesService _officersMilitaryDegreesService;
        private readonly IPowerTypesService _powerTypesService;
        private readonly IDepartmentServices _departmentServices;

        public PoliceOfficersController(
            IPoliceOfficersService policeOfficersService,
            IOfficersMilitaryDegreesService officersMilitaryDegreesService,
            IPowerTypesService powerTypesService,
            IDepartmentServices departmentServices)
        {
            _policeOfficersService = policeOfficersService;
            _officersMilitaryDegreesService = officersMilitaryDegreesService;
            _powerTypesService = powerTypesService;
            _departmentServices = departmentServices;
        }

        public async Task<IActionResult> GetAll()
        {
            var policeOfficers = await _policeOfficersService.GetAll();

            var policeOficersViewModel = new GetAllPoliceOfficersViewModel
            {
                PoliceOfficers = policeOfficers.ToList(),
                OfficersMililaryDegrees = await _officersMilitaryDegreesService.GetAll(),
                PowerTypes = await _powerTypesService.GetAll(),
                Departments = await _departmentServices.GetAll()
            };

            return View(policeOficersViewModel);
        }

        public async Task<IActionResult> AddOrUpdate(GetAllPoliceOfficersViewModel model)
        {
            await _policeOfficersService.AddOrUpdate(model.PoliceOfficer);

            return RedirectToAction(nameof(GetAll));
        }

        public async Task<IActionResult> Delete(long id)
        {
            await _policeOfficersService.Delete(id);

            return RedirectToAction(nameof(GetAll));
        }

        //public async Task<IActionResult> GetById(long id)
        //{
        //    var policeOfficer = await _policeOfficersService.GetById(id);
        //    return View(policeOfficer);
        //}
    }
}
