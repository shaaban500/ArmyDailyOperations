using DailyOperations.Domain.Interfaces.Services.Operations;
using DailyOperations.Domain.ViewModels.Operations;
using Microsoft.AspNetCore.Mvc;

namespace DailyOperations.Api.Controllers.Operations
{
	public class GeneralDepartmentsController : Controller
	{
		private readonly IGeneralDepartmentServices _generalDepartmentServices;
		public GeneralDepartmentsController(IGeneralDepartmentServices generalDepartmentServices)
		{
			_generalDepartmentServices = generalDepartmentServices;
		}

		public async Task<IActionResult> AddOrUpdate(GetAllOperationsViewModel model)
		{
			await _generalDepartmentServices.AddOrUpdate(model.GeneralDepartment);
			return RedirectToAction("GetAll", "Operations" , model);
		}
	}
}
