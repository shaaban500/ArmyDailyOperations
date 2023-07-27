using DailyOperations.Domain.Interfaces.Services.Operations;
using DailyOperations.Domain.ViewModels.Operations;
using DailyOperations.Infrastructure.Services.Operations;
using Microsoft.AspNetCore.Mvc;

namespace DailyOperations.Api.Controllers.Operations
{
	public class OperationVehiclesController : Controller
	{
		private readonly IOperationVehicleServices _operationVehicleServices;
		public OperationVehiclesController(IOperationVehicleServices operationVehicleServices)
		{
			_operationVehicleServices = operationVehicleServices;
		}

		[HttpGet]
		public async Task<IActionResult> Search()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Search(GetAllOperationsViewModel model)
		{
			var operationOfficers = await _operationVehicleServices.Search(model.SelectedDateVehicleSearch);

			var getAllOperationsViewModel = new GetAllOperationsViewModel
			{
			};

			return View(getAllOperationsViewModel);
		}
		public async Task<IActionResult> Delete(long id, long operationId)
		{
			await _operationVehicleServices.Delete(id);
			return RedirectToAction("GetAll", "Operations", new GetAllOperationsViewModel { OperationId = operationId });
		}
	}
}
