using DailyOperations.Domain.Interfaces.Services;
using DailyOperations.Domain.ViewModels.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace DailyOperations.Api.Controllers.Members
{
    public class VehicleMarksController : Controller
    {
        private readonly IVehicleMarksService _vehicleMarksService;
        public VehicleMarksController(IVehicleMarksService vehicleMarksService)
        {
            _vehicleMarksService = vehicleMarksService;
        }

        public async Task<IActionResult> GetAll()
        {
            var vehicleMarks = await _vehicleMarksService.GetAll();
            return View(vehicleMarks);
        }

        public async Task<IActionResult> AddOrUpdate(GetAllVehiclesViewModel model)
        {
            await _vehicleMarksService.AddOrUpdate(model.VehicleMark);

            return RedirectToAction(nameof(GetAll), "Vehicles");
        }

        public async Task<IActionResult> Delete(long id)
        {
            await _vehicleMarksService.Delete(id);

            return RedirectToAction(nameof(GetAll), "Vehicles");
        }
    }
}
