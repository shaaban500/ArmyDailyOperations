using DailyOperations.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DailyOperations.Api.Controllers.Operations
{
	public class OperationDescriptionController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public OperationDescriptionController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IActionResult> GetAll()
		{
			var operationDescriptions = await _unitOfWork.OperationDescriptions.GetAllAsync();
			return View(operationDescriptions.ToList());
		}

		public async Task<IActionResult> Add()
		{
			return View();
		}
	}
}
