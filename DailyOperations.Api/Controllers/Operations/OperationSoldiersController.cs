using DailyOperations.Domain.Interfaces.Services;
using DailyOperations.Domain.Interfaces.Services.Operations;
using DailyOperations.Domain.ViewModels.Operations;
using Microsoft.AspNetCore.Mvc;

namespace DailyOperations.Api.Controllers.Operations
{
	public class OperationSoldiersController : Controller
	{
		private readonly IsoldiersService _soldierServices;
		private readonly IOperatinSoldierServices _operatinSoldierServices;
		public OperationSoldiersController(IOperatinSoldierServices operatinSoldierServices, IsoldiersService soldierServices)
		{
			_operatinSoldierServices = operatinSoldierServices;
			_soldierServices = soldierServices;
		}

		[HttpGet]
		public async Task<IActionResult> Search()
		{
			var model = new GetAllOperationsViewModel
			{
				Soldiers = await _soldierServices.GetAll()
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Search(GetAllOperationsViewModel model)
		{
			var operationSoldiers = await _operatinSoldierServices.Search(model.SoldierId, model.SearchDateFrom, model.SearchDateTo);

			var getAllOperationsViewModel = new GetAllOperationsViewModel
			{
				Soldiers = await _soldierServices.GetAll(),
				DailyOperationViewModel = new DailyOperationViewModel
				{
					OperatinSoldiers = operationSoldiers
				},
			};

			return View(getAllOperationsViewModel);
		}

		public async Task<IActionResult> Delete(long id, long operationId)
		{
			await _operatinSoldierServices.Delete(id);
			return RedirectToAction("GetAll", "Operations", new GetAllOperationsViewModel { OperationId = operationId });
		}
	}
}
