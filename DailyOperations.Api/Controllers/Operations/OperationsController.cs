using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services;
using DailyOperations.Domain.Interfaces.Services.Holidays;
using DailyOperations.Domain.Interfaces.Services.Operations;
using DailyOperations.Domain.ViewModels.Operations;
using Microsoft.AspNetCore.Mvc;

public class OperationsController : Controller
{
	private readonly IDailyOperationServices _dailyOperationServices;
	private readonly IGeneralDepartmentServices _generalDepartmentServices;
	private readonly IInnerDepartmentServices _innerDepartmentServices;
	private readonly IOperatinSoldierServices _operatinSoldierServices;
	private readonly IOperationDescriptionServices _operationDescriptionServices;
	private readonly IOperationServices _operationServices;
	private readonly IOperationTypeServices _operationTypeServices;
	private readonly ISectorPlaceServices _sectorPlaceServices;
	private readonly ISectorServices _sectorServices;
	private readonly IShiftTypeServices _shiftTypeServices;
	private readonly IsoldiersService _soldiersService;
	private readonly IHolidayServices _holidayService;
	private readonly IUnitOfWork _unitOfWork;

	public OperationsController(
		IDailyOperationServices dailyOperationServices,
		IGeneralDepartmentServices generalDepartmentServices,
		IInnerDepartmentServices innerDepartmentServices,
		IOperatinSoldierServices operatinSoldierServices,
		IOperationDescriptionServices operationDescriptionServices,
		IOperationServices operationServices,
		IOperationTypeServices operationTypeServices,
		ISectorPlaceServices sectorPlaceServices,
		ISectorServices sectorServices,
		IShiftTypeServices shiftTypeServices,
		IsoldiersService soldiersService,
		IUnitOfWork unitOfWork,
		IHolidayServices holidayService)
	{
		_dailyOperationServices = dailyOperationServices;
		_generalDepartmentServices = generalDepartmentServices;
		_innerDepartmentServices = innerDepartmentServices;
		_operatinSoldierServices = operatinSoldierServices;
		_operationDescriptionServices = operationDescriptionServices;
		_operationServices = operationServices;
		_operationTypeServices = operationTypeServices;
		_sectorPlaceServices = sectorPlaceServices;
		_sectorServices = sectorServices;
		_shiftTypeServices = shiftTypeServices;
		_soldiersService = soldiersService;
		_unitOfWork = unitOfWork;
		_holidayService = holidayService;
	}

	public async Task<IActionResult> GetAll(GetAllOperationsViewModel model)
	{
		// table titles
		model.DailyOperationViewModel.Operation = await _operationServices.GetById(model.OperationId);


		// all daily operations for specific operationId for Table
		model.GroupedSoldierOperations = await _operatinSoldierServices.GetAll(model.OperationId);


		// members drop down lists unique (choosen member can not be choosen again)
		model.Soldiers = await _soldiersService.GetAll(model.OperationId);
		model.TotalSoldiersCount = await _soldiersService.GetCount();
		model.TotalHolidayCount = await _holidayService.GetHolidaysCount(model.OperationId);

		// all dropdown lists
		model.DailyOperations = await _dailyOperationServices.GetAll();
		model.GeneralDepartments = await _generalDepartmentServices.GetAll();
		model.InnerDepartments = await _innerDepartmentServices.GetAll();
		model.OperationDescriptions = await _operationDescriptionServices.GetAll();
		model.OperationTypes = await _operationTypeServices.GetAll();
		model.SectorPlaces = await _sectorPlaceServices.GetAll();
		model.Sectors = await _sectorServices.GetAll();
		model.ShiftTypes = await _shiftTypeServices.GetAll();

		for (int i = 1; i <= 24; i++)
		{
			model.Times.Add(i);
		}

		return View(model);
	}


	public async Task<IActionResult> AddOrUpdate(GetAllOperationsViewModel model)
	{
		var addedModel = await _operationServices.AddorUpdate(model);
		return RedirectToAction(nameof(GetAll), model);
	}


	public async Task<IActionResult> AddOperationForMembers(GetAllOperationsViewModel model)
	{
		if (model.DriverData is not null)
		{
			var driverData = model.DriverData.Split("|");

			if (driverData is not null && driverData.Length > 0)
				model.DriverId = Convert.ToInt64(driverData[0]);

			if (driverData is not null && driverData.Length > 1)
				model.DriverType = Convert.ToInt64(driverData[1]);
		}


		if (model.SoldierId != 0)
		{
			var operationSoldier = await _operatinSoldierServices.Add(model);
		}


		return RedirectToAction(nameof(GetAll), model);
	}


}