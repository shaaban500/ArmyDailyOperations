using DailyOperations.Domain.Interfaces.Services.Members;
using DailyOperations.Domain.Interfaces.Services.Operations;
using DailyOperations.Domain.ViewModels.Operations;
using Microsoft.AspNetCore.Mvc;

namespace DailyOperations.Api.Controllers.Operations
{
	public class OperationOfficersController : Controller
	{
		private readonly IPoliceOfficersService _policeOfficersService;
		private readonly IOperationOfficerServices _operationOfficerServices;
		public OperationOfficersController(IOperationOfficerServices operationOfficerServices, IPoliceOfficersService policeOfficersService)
		{
			_operationOfficerServices = operationOfficerServices;
			_policeOfficersService = policeOfficersService;
		}

		[HttpGet]
		public async Task<IActionResult> Search()
		{
			var model = new GetAllOperationsViewModel
			{
				PoliceOfficers = await _policeOfficersService.GetAll()
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Search(GetAllOperationsViewModel model)
		{
			var operationOfficers = await _operationOfficerServices.Search(model.PoliceOfficerId, model.SearchDateFrom, model.SearchDateTo);

			var getAllOperationsViewModel = new GetAllOperationsViewModel
			{
				PoliceOfficers = await _policeOfficersService.GetAll(),
				DailyOperationViewModel = new DailyOperationViewModel
				{
					OperationOfficers = operationOfficers
				},
			};

			return View(getAllOperationsViewModel);
		}


		public async Task<IActionResult> Delete(long id, long operationId)
		{
			await _operationOfficerServices.Delete(id);
			return RedirectToAction("GetAll", "Operations", new GetAllOperationsViewModel { OperationId = operationId });
		}

	}
}
