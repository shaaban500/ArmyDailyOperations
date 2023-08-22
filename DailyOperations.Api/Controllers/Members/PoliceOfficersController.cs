using DailyOperations.Domain.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;

        public PoliceOfficersController(
            IPoliceOfficersService policeOfficersService,
            IOfficersMilitaryDegreesService officersMilitaryDegreesService,
            IPowerTypesService powerTypesService,
            IDepartmentServices departmentServices,
            IUnitOfWork unitOfWork)
        {
            _policeOfficersService = policeOfficersService;
            _officersMilitaryDegreesService = officersMilitaryDegreesService;
            _powerTypesService = powerTypesService;
            _departmentServices = departmentServices;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> GetAll()
        {
            var policeOfficers = await _policeOfficersService.GetAll();

            var generalDepartments = await _unitOfWork.GeneralDepartments.GetAllAsync();
            var innerDepartments = await _unitOfWork.InnerDepartments.GetAllAsync();

            var policeOficersViewModel = new GetAllPoliceOfficersViewModel
            {
                PoliceOfficers = policeOfficers.ToList(),
                OfficersMililaryDegrees = await _officersMilitaryDegreesService.GetAll(),
                PowerTypes = await _powerTypesService.GetAll(),
                GeneralDepartments = generalDepartments.ToList(),
                InnerDepartments = innerDepartments.ToList(),
            };

            return View(policeOficersViewModel);
        }


		public async Task<IActionResult> GetAllByDepartment(long id)
        {
            var officers = await _unitOfWork.PoliceOfficers.GetAllAsync(x => x.InnerDepartmentId == id);
            return Ok(officers);
        }


		public async Task<IActionResult> AddOrUpdate(GetAllPoliceOfficersViewModel model)
        {
            await _policeOfficersService.AddOrUpdate(model);

            return RedirectToAction(nameof(GetAll));
        }

        public async Task<IActionResult> Delete(long id)
        {
            await _policeOfficersService.Delete(id);

            return RedirectToAction(nameof(GetAll));
        }


        public async Task<IActionResult> GeneralDepartment(GetAllPoliceOfficersViewModel model)
        {
            var generalDepartment = await _unitOfWork.GeneralDepartments.GetByIdAsync(null, x => x.Department == model.GeneralDepartment.Department);

            if (generalDepartment == null)
            {
                var addedDepartment = await _unitOfWork.GeneralDepartments.AddAsync(model.GeneralDepartment);
            }

            return RedirectToAction(nameof(GetAll));
        }

        public async Task<IActionResult> InnerDepartment(GetAllPoliceOfficersViewModel model)
        {
            var innerDepartment = await _unitOfWork.InnerDepartments.GetByIdAsync(null, x => x.Department == model.InnerDepartment.Department);

            if (innerDepartment == null)
            {
                var addedDepartment = await _unitOfWork.InnerDepartments.AddAsync(model.InnerDepartment);
            }

            return RedirectToAction(nameof(GetAll));
        }

    }
}
