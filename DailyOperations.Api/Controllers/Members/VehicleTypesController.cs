using DailyOperations.Domain.Interfaces.Services;
using DailyOperations.Domain.ViewModels.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace DailyOperations.Api.Controllers.Members
{
    public class VehicleTypesController : Controller
    {
        private readonly IVehicleTypesService _vahicleTypeService;
        public VehicleTypesController(IVehicleTypesService vehicleTypesService)
        {
            _vahicleTypeService = vehicleTypesService;
        }

        public async Task<IActionResult> GetAll()
        {
            var vehicleTypes = await _vahicleTypeService.GetAll();
            return View(vehicleTypes);
        }

        public async Task<IActionResult> AddOrUpdate(GetAllVehiclesViewModel model)
        {
            await _vahicleTypeService.AddOrUpdate(model.VehicleType);

            return RedirectToAction(nameof(GetAll), "Vehicles");
        }

        public async Task<IActionResult> Delete(long id)
        {
            await _vahicleTypeService.Delete(id);

            return RedirectToAction(nameof(GetAll), "Vehicles");
        }
    }
}
