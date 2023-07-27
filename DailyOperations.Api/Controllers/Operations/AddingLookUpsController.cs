using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.ViewModels.Operations;
using Microsoft.AspNetCore.Mvc;

namespace DailyOperations.Api.Controllers.Operations
{
	public class AddingLookUpsController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public AddingLookUpsController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IActionResult> GeneralDepartment(GetAllOperationsViewModel model)
		{
			var generalDepartment = await _unitOfWork.GeneralDepartments.GetByIdAsync(null, x => x.Department == model.GeneralDepartment.Department);
			
			if(generalDepartment == null) 
			{
				var addedDepartment = await _unitOfWork.GeneralDepartments.AddAsync(model.GeneralDepartment);
			}
			
			return RedirectToAction("GetAll", "Operations", model);
		}

		public async Task<IActionResult> InnerDepartment(GetAllOperationsViewModel model)
		{
			var innerDepartment = await _unitOfWork.InnerDepartments.GetByIdAsync(null, x => x.Department == model.InnerlDepartment.Department);

			if (innerDepartment == null)
			{
				var addedDepartment = await _unitOfWork.InnerDepartments.AddAsync(model.InnerlDepartment);
			}

			return RedirectToAction("GetAll", "Operations", model);
		}

		public async Task<IActionResult> DailyOperation(GetAllOperationsViewModel model)
		{
			var dailyOperation = await _unitOfWork.DailyOperations.GetByIdAsync(null, x => x.DailyOperationName == model.DailyOperation.DailyOperationName);

			if (dailyOperation == null)
			{
				var addedDailyOperation = await _unitOfWork.DailyOperations.AddAsync(model.DailyOperation);
			}

			return RedirectToAction("GetAll", "Operations", model);
		}

		public async Task<IActionResult> ShiftType(GetAllOperationsViewModel model)
		{
			var shiftType = await _unitOfWork.ShiftTypes.GetByIdAsync(null, x => x.Type == model.ShiftType.Type);

			if (shiftType == null)
			{
				var addedShiftType = await _unitOfWork.ShiftTypes.AddAsync(model.ShiftType);
			}

			return RedirectToAction("GetAll", "Operations", model);
		}

		public async Task<IActionResult> Sector(GetAllOperationsViewModel model)
		{
			var sector = await _unitOfWork.Sectors.GetByIdAsync(null, x => x.SectorName == model.Sector.SectorName);

			if (sector == null)
			{
				var addedSector = await _unitOfWork.Sectors.AddAsync(model.Sector);
			}

			return RedirectToAction("GetAll", "Operations", model);
		}

		public async Task<IActionResult> SectorPlace(GetAllOperationsViewModel model)
		{
			var sectorPlace = await _unitOfWork.SectorPlaces.GetByIdAsync(null, x => x.SectorPlaceName == model.SectorPlace.SectorPlaceName);

			if (sectorPlace == null)
			{
				var addedSectorPlace = await _unitOfWork.SectorPlaces.AddAsync(model.SectorPlace);
			}

			return RedirectToAction("GetAll", "Operations", model);
		}

		public async Task<IActionResult> OperationType(GetAllOperationsViewModel model)
		{
			var operationType = await _unitOfWork.OperationTypes.GetByIdAsync(null, x => x.Type == model.OperationType.Type);

			if (operationType == null)
			{
				var addedOperationType = await _unitOfWork.OperationTypes.AddAsync(model.OperationType);
			}

			return RedirectToAction("GetAll", "Operations", model);
		}

		public async Task<IActionResult> OperationDescription(GetAllOperationsViewModel model)
		{
			var operationDescreiption = await _unitOfWork.OperationDescriptions.GetByIdAsync(null, x => x.Description == model.OperationDescription.Description);

			if (operationDescreiption == null)
			{
				var addedOperationDescreiption = await _unitOfWork.OperationDescriptions.AddAsync(model.OperationDescription);
			}

			return RedirectToAction("GetAll", "Operations", model);
		}

		public async Task<IActionResult> OperationInstruction(GetAllOperationsViewModel model)
		{
			var operationInstruction = await _unitOfWork.OperationInstructions.GetByIdAsync(null, x => x.Instruction == model.OperationInstruction.Instruction);

			if (operationInstruction == null)
			{
				var addedOperationInstruction = await _unitOfWork.OperationInstructions.AddAsync(model.OperationInstruction);
			}

			return RedirectToAction("GetAll", "Operations", model);
		}
	}
}
