using System.Linq.Expressions;
using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services;
using DailyOperations.Domain.Interfaces.Services.Members;
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
    private readonly IOperationInstructionServices _operationInstructionServices;
    private readonly IOperationOfficerServices _operationOfficerServices;
    private readonly IOperationPoliceAssistantServices _operationPoliceAssistantServices;
    private readonly IOperationServices _operationServices;
    private readonly IOperationTypeServices _operationTypeServices;
    private readonly IOperationVehicleServices _operationVehicleServices;
    private readonly ISectorPlaceServices _sectorPlaceServices;
    private readonly ISectorServices _sectorServices;
    private readonly IShiftTypeServices _shiftTypeServices;
    private readonly IPoliceOfficersService _policeOfficersService;
    private readonly IpoliceAssistantsService _policeAssistantsService;
    private readonly IsoldiersService _soldiersService;
    private readonly IVehicleTypesService _vehicleTypesService;
    private readonly IVehiclesService _vehiclesService;
    private readonly IUnitOfWork _unitOfWork;
	public OperationsController(
		IDailyOperationServices dailyOperationServices,
		IGeneralDepartmentServices generalDepartmentServices,
		IInnerDepartmentServices innerDepartmentServices,
		IOperatinSoldierServices operatinSoldierServices,
		IOperationDescriptionServices operationDescriptionServices,
		IOperationInstructionServices operationInstructionServices,
		IOperationOfficerServices operationOfficerServices,
		IOperationPoliceAssistantServices operationPoliceAssistantServices,
		IOperationServices operationServices,
		IOperationTypeServices operationTypeServices,
		IOperationVehicleServices operationVehicleServices,
		ISectorPlaceServices sectorPlaceServices,
		ISectorServices sectorServices,
		IShiftTypeServices shiftTypeServices,
		IPoliceOfficersService policeOfficersService,
		IpoliceAssistantsService policeAssistantsService,
		IsoldiersService soldiersService,
		IVehicleTypesService vehicleTypesService,
		IVehiclesService vehiclesService,
		IUnitOfWork unitOfWork)
	{
		_dailyOperationServices = dailyOperationServices;
		_generalDepartmentServices = generalDepartmentServices;
		_innerDepartmentServices = innerDepartmentServices;
		_operatinSoldierServices = operatinSoldierServices;
		_operationDescriptionServices = operationDescriptionServices;
		_operationInstructionServices = operationInstructionServices;
		_operationOfficerServices = operationOfficerServices;
		_operationPoliceAssistantServices = operationPoliceAssistantServices;
		_operationServices = operationServices;
		_operationTypeServices = operationTypeServices;
		_operationVehicleServices = operationVehicleServices;
		_sectorPlaceServices = sectorPlaceServices;
		_sectorServices = sectorServices;
		_shiftTypeServices = shiftTypeServices;
		_policeOfficersService = policeOfficersService;
		_policeAssistantsService = policeAssistantsService;
		_soldiersService = soldiersService;
		_vehicleTypesService = vehicleTypesService;
		_vehiclesService = vehiclesService;
		_unitOfWork = unitOfWork;
	}

	public async Task<IActionResult> GetAll(GetAllOperationsViewModel model)
    {
		// table titles
		model.DailyOperationViewModel.Operation = await _operationServices.GetById(model.OperationId);
        
        
        // all daily operations for specific operationId for Table
        model.DailyOperationViewModel.OperatinSoldiers = await _operatinSoldierServices.GetAll(model.OperationId);
        model.DailyOperationViewModel.OperationOfficers = await _operationOfficerServices.GetAll(model.OperationId);
        model.DailyOperationViewModel.OperationPoliceAssistants = await _operationPoliceAssistantServices.GetAll(model.OperationId);
        model.OperationVehiclesViewModel = await _operationVehicleServices.GetAll(model.OperationId);


		foreach (var operationOfficer in model.DailyOperationViewModel.OperationOfficers)
		{
			var includes = new Expression<Func<OperationVehicle, object>>[]
			{
				p => p.Vehicle,
				p => p.Vehicle.VehicleType,
			};

			var operationVehicel = await _unitOfWork.OperationVehicles.GetByIdAsync(null, x => 
                    x.RelatedOperationType == 1 && 
                    x.RelatedOperationId == operationOfficer.Id,
                    includes);
            
			var operationOfficerViewModel = new OperationOfficerViewModel
            {
                OperationOfficer = operationOfficer,
                OperationVehicle = operationVehicel,
            };

            if(operationVehicel is not null)
            {
                if(operationVehicel?.DriverType == 1)
                {
                    var officer = await _unitOfWork.PoliceOfficers.GetByIdAsync(operationVehicel?.DriverId, null, x => x.OfficerMilitaryDegree);
                    
                    if(officer is not null)
                        operationOfficerViewModel.DriverName = $"{officer.OfficerMilitaryDegree.Degree} / {officer?.Name}";
                }
                else if(operationVehicel?.DriverType == 2)
                {
                    var assistant = await _unitOfWork.PoliceAssistants.GetByIdAsync(operationVehicel?.DriverId, null, x=>x.AssistantsMilitaryDegree);
                    
                    if(assistant is not null)
                        operationOfficerViewModel.DriverName = $" {assistant.AssistantsMilitaryDegree.Degree} / {assistant?.Name}";
                }
			    else if (operationVehicel?.DriverType == 3)
				{
				    var soldier = await _unitOfWork.Soldiers.GetByIdAsync(operationVehicel?.DriverId);
				        
                    if (soldier is not null)
                        operationOfficerViewModel.DriverName = $"مجند / {soldier?.Name}";
			    }
            }

			model.OperationOfficersViewModel?.Add(operationOfficerViewModel);
        }

        
        // members drop down lists unique (choosen member can not be choosen again)
        model.PoliceOfficers = await _policeOfficersService.GetAll(model.OperationId);
        model.PoliceAssistants = await _policeAssistantsService.GetAll(model.OperationId);
        model.Soldiers = await _soldiersService.GetAll(model.OperationId);
        model.Vehicles = await _vehiclesService.GetAll(model.OperationId);

        // all dropdown lists
        model.DailyOperations = await _dailyOperationServices.GetAll();
        model.GeneralDepartments = await _generalDepartmentServices.GetAll();
        model.InnerDepartments = await _innerDepartmentServices.GetAll();
        model.OperationDescriptions = await _operationDescriptionServices.GetAll();
        model.OperationInstructions = await _operationInstructionServices.GetAll();
        model.OperationTypes = await _operationTypeServices.GetAll();
        model.SectorPlaces = await _sectorPlaceServices.GetAll();
        model.Sectors = await _sectorServices.GetAll();
        model.ShiftTypes = await _shiftTypeServices.GetAll();
        model.VehicleTypes = await _vehicleTypesService.GetAll();

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
		if(model.DriverData is not null)
		{
			var driverData = model.DriverData.Split("|");

			if(driverData is not null &&  driverData.Length > 0)
				model.DriverId = Convert.ToInt64(driverData[0]);

			if (driverData is not null && driverData.Length > 1)
				model.DriverType = Convert.ToInt64(driverData[1]);
		}


        var operationOfficer = new OperationOfficer();


        if (model.PoliceOfficerId != 0)
        {
            operationOfficer = await _operationOfficerServices.Add(model);
        }

        if (model.PoliceAssistantId != 0)
        {
			var operationAssistant = await _operationPoliceAssistantServices.Add(model);
        }

        if (model.SoldierId != 0)
        {
            var operationSoldier = await _operatinSoldierServices.Add(model);
        }

        if (model.VehicleId != 0 && model.DriverId != 0 && model.DriverType != 0)
        {
            var operationVehicle = await _operationVehicleServices.Add(model, operationOfficer.Id == 0 ? 0 : 1, operationOfficer.Id == 0 ? 0 : operationOfficer.Id);
        }

        return RedirectToAction(nameof(GetAll), model);
    }



}