using DailyOperations.Domain.Interfaces.Services;
using DailyOperations.Domain.ViewModels.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace DailyOperations.Api.Controllers.Members
{
    public class VehiclesController : Controller
    {
        private IVehiclesService _vehiclesService;
        private IVehicleMarksService _vehicleMarksService;
        private IVehicleTypesService _vehicleTypesService;
        public VehiclesController(
            IVehiclesService vehiclesService,
            IVehicleMarksService vehicleMarksService,
            IVehicleTypesService vehicleTypesService)
        {
            _vehiclesService = vehiclesService;
            _vehicleMarksService = vehicleMarksService;
            _vehicleTypesService = vehicleTypesService;
        }

        public async Task<IActionResult> GetAll()
        {
            var vehiclesViewModel = new GetAllVehiclesViewModel
            {
                Vehicles = await _vehiclesService.GetAll(),
                VehicleMarks = await _vehicleMarksService.GetAll(),
                VehicleTypes = await _vehicleTypesService.GetAll()
            };

            return View(vehiclesViewModel);
        }

        public async Task<IActionResult> AddOrUpdate(GetAllVehiclesViewModel model)
        {
            await _vehiclesService.AddOrUpdate(model.Vehicle);
            return RedirectToAction(nameof(GetAll));
        }

        public async Task<IActionResult> Delete(long id)
        {
            await _vehiclesService.Delete(id);
            return RedirectToAction(nameof(GetAll));
        }
    }
}
