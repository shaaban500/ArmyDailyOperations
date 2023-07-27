using DailyOperations.Domain.Interfaces.Services;
using DailyOperations.Domain.Interfaces.Services.Operations;
using DailyOperations.Domain.ViewModels.Operations;
using Microsoft.AspNetCore.Mvc;

namespace DailyOperations.Api.Controllers.Operations
{
	public class OperationAssistantsController : Controller
	{
		private readonly IpoliceAssistantsService _policeAssistantsService;
		private readonly IOperationPoliceAssistantServices _operationPoliceAssistantServices;
		public OperationAssistantsController(IpoliceAssistantsService policeAssistantsService, IOperationPoliceAssistantServices operationPoliceAssistantServices)
		{
			_policeAssistantsService = policeAssistantsService;
			_operationPoliceAssistantServices = operationPoliceAssistantServices;
		}


		[HttpGet]
		public async Task<IActionResult> Search()
		{
			var model = new GetAllOperationsViewModel
			{
				PoliceAssistants = await _policeAssistantsService.GetAll()
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Search(GetAllOperationsViewModel model)
		{
			var operationAssistants = await _operationPoliceAssistantServices.Search(model.PoliceAssistantId, model.SearchDateFrom, model.SearchDateTo);

			var getAllOperationsViewModel = new GetAllOperationsViewModel
			{
				PoliceAssistants = await _policeAssistantsService.GetAll(),
				DailyOperationViewModel = new DailyOperationViewModel
				{
					OperationPoliceAssistants = operationAssistants
				},
			};

			return View(getAllOperationsViewModel);
		}


		public async Task<IActionResult> Delete(long id, long operationId)
		{
			await _operationPoliceAssistantServices.Delete(id);
			return RedirectToAction("GetAll", "Operations", new GetAllOperationsViewModel { OperationId = operationId });
		}

	}
}
