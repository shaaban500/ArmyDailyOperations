using System.Linq.Expressions;
using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Operations;
using DailyOperations.Domain.ViewModels.Operations;

namespace DailyOperations.Infrastructure.Services.Operations
{
    public class OperationVehicleServices : IOperationVehicleServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public OperationVehicleServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

		public async Task<OperationVehicle> Add(GetAllOperationsViewModel model, int operationType = 0, long relatedOperationId = 0)
		{
			var operation = await _unitOfWork.Operations.GetByIdAsync(model.OperationId);

			if (operation is null)
			{
				return new OperationVehicle();
			}

			var operationVehicle = new OperationVehicle
			{
				OperationId = model.OperationId,
				OperationDescriptionId = model.OperationDescriptionId,
				OperationInstructionId = model.OperationInstructionId,
				OperationTypeId = model.OperationTypeId,
				VehicleId = model.VehicleId,
				DriverId = model.DriverId,
				DriverType = model.DriverType,
				RelatedOperationType = operationType,
				RelatedOperationId = relatedOperationId,
				TimeFrom = model.OperationTimeFrom == 0 ? operation.ShiftTimeFrom : model.OperationTimeFrom,
				TimeTo = model.OperationTimeTo == 0 ? operation.ShiftTimeTo : model.OperationTimeTo,
			};

			var addedOperationVehicle = await _unitOfWork.OperationVehicles.AddAsync(operationVehicle);
			return addedOperationVehicle;
		}


        public async Task<List<OperationVehicle>> GetAll()
        {
            var operationVehicles = await _unitOfWork.OperationVehicles.GetAllAsync();
            return operationVehicles.ToList();
        }

		public async Task<List<OperationVehicleViewModel>> GetAll(long operationId)
		{
			var operationVehiclesIncludes = new Expression<Func<OperationVehicle, object>>[]
			{
				p => p.Vehicle,
				p => p.Vehicle.VehicleType,
				p => p.OperationDescription,
				p => p.OperationInstruction,
				p => p.OperationType
			};

			var operationVehicles = await _unitOfWork.OperationVehicles.GetAllAsync(x => 
				x.OperationId == operationId,
				p => p.OrderBy(a => a.RelatedOperationType == 0 ? int.MaxValue : a.RelatedOperationType),
				operationVehiclesIncludes);


			var allOperationVehicles = new List<OperationVehicleViewModel>();

			foreach(var operationVehicle in operationVehicles)
			{
				var driverType = operationVehicle.DriverType;
				var driverId =  operationVehicle.DriverId;

				var operationVehicleViewModel = new OperationVehicleViewModel 
				{
					OperationVehicle = operationVehicle
				};


				if(driverType == 1)
				{
					var officer = await _unitOfWork.PoliceOfficers.GetByIdAsync(driverId, null, x => x.OfficerMilitaryDegree);
					operationVehicleViewModel.DriverName = $"{officer.OfficerMilitaryDegree.Degree} / {officer?.Name}";
				}
				else if(driverType == 2)
				{
					var assistant = await _unitOfWork.PoliceAssistants.GetByIdAsync(driverId, null, x => x.AssistantsMilitaryDegree);
					operationVehicleViewModel.DriverName = $" {assistant.AssistantsMilitaryDegree.Degree} / {assistant?.Name}";
				}
				else if(driverType == 3)
				{
					var soldier = await _unitOfWork.Soldiers.GetByIdAsync(driverId);
					operationVehicleViewModel.DriverName = $"مجند / {soldier?.Name}";
				}


				var relatedOperationType = operationVehicle.RelatedOperationType;
				var relatedOperationId = operationVehicle.RelatedOperationId;

				if(relatedOperationType == 0 || relatedOperationId == 0) 
				{
					allOperationVehicles.Add(operationVehicleViewModel);
					continue;
				}


				if (relatedOperationType == 1)
				{
					var operationOfficer = await _unitOfWork.OperationOfficers.GetByIdAsync(relatedOperationId);
					operationVehicleViewModel.OfficerName = $"{operationOfficer?.PoliceOfficer.OfficerMilitaryDegree.Degree} / {operationOfficer?.PoliceOfficer.Name}";
				}
				else if (relatedOperationType == 2)
				{
					var operationAssistant = await _unitOfWork.OperationPoliceAssistants.GetByIdAsync(relatedOperationId);
					operationVehicleViewModel.OfficerName = $"{operationAssistant?.PoliceAssistant.AssistantsMilitaryDegree.Degree} / {operationAssistant?.PoliceAssistant.Name}";
				}
				else if (relatedOperationType == 3)
				{
					var operationSoldier = await _unitOfWork.OperationSoldiers.GetByIdAsync(relatedOperationId);
					operationVehicleViewModel.OfficerName = $"مجند / {operationSoldier?.Soldier.Name}";
				}

				allOperationVehicles.Add(operationVehicleViewModel);
			}

			return allOperationVehicles;
		}

		public async Task<List<OperationVehicleViewModel>> Search(DateTime date)
		{
			throw new NotImplementedException();
		
			//var operationVehiclesIncludes = new Expression<Func<OperationVehicle, object>>[]
			//			{
			//				p => p.Vehicle,
			//				p => p.Vehicle.VehicleType,
			//				p => p.OperationDescription,
			//				p => p.OperationInstruction,
			//				p => p.OperationType,
			//				p => p.Operation.,
			//			};

			//var operationVehicles = await _unitOfWork.OperationVehicles.GetAllAsync(x =>
			//	x.Operation.Date == date,
			//	p => p.OrderBy(a => a.RelatedOperationType == 0 ? int.MaxValue : a.RelatedOperationType),
			//	operationVehiclesIncludes);


			//var allOperationVehicles = new List<OperationVehicleViewModel>();

			//foreach (var operationVehicle in operationVehicles)
			//{
			//	var driverType = operationVehicle.DriverType;
			//	var driverId = operationVehicle.DriverId;

			//	var operationVehicleViewModel = new OperationVehicleViewModel
			//	{
			//		OperationVehicle = operationVehicle
			//	};


			//	if (driverType == 1)
			//	{
			//		var officer = await _unitOfWork.PoliceOfficers.GetByIdAsync(driverId);
			//		operationVehicleViewModel.DriverName = officer?.Name;
			//	}
			//	else if (driverType == 2)
			//	{
			//		var assistant = await _unitOfWork.PoliceAssistants.GetByIdAsync(driverId);
			//		operationVehicleViewModel.DriverName = assistant?.Name;
			//	}
			//	else if (driverType == 3)
			//	{
			//		var soldier = await _unitOfWork.Soldiers.GetByIdAsync(driverId);
			//		operationVehicleViewModel.DriverName = soldier?.Name;
			//	}


			//	var relatedOperationType = operationVehicle.RelatedOperationType;
			//	var relatedOperationId = operationVehicle.RelatedOperationId;

			//	if (relatedOperationType == 0 || relatedOperationId == 0)
			//	{
			//		allOperationVehicles.Add(operationVehicleViewModel);
			//		continue;
			//	}


			//	if (relatedOperationType == 1)
			//	{
			//		var operationOfficer = await _unitOfWork.OperationOfficers.GetByIdAsync(relatedOperationId);
			//		operationVehicleViewModel.OfficerName = $"{operationOfficer?.PoliceOfficer.OfficerMilitaryDegree.Degree} / {operationOfficer?.PoliceOfficer.Name}";
			//	}
			//	else if (relatedOperationType == 2)
			//	{
			//		var operationAssistant = await _unitOfWork.OperationPoliceAssistants.GetByIdAsync(relatedOperationId);
			//		operationVehicleViewModel.OfficerName = $"{operationAssistant?.PoliceAssistant.AssistantsMilitaryDegree.Degree} / {operationAssistant?.PoliceAssistant.Name}";
			//	}
			//	else if (relatedOperationType == 3)
			//	{
			//		var operationSoldier = await _unitOfWork.OperationSoldiers.GetByIdAsync(relatedOperationId);
			//		operationVehicleViewModel.OfficerName = $"مجند / {operationSoldier?.Soldier.Name}";
			//	}

			//	allOperationVehicles.Add(operationVehicleViewModel);
			//}

			//return allOperationVehicles;
		}

        public async Task Delete(long id)
        {
			var operationVehicle = await _unitOfWork.OperationVehicles.GetByIdAsync(id);
			
			if(operationVehicle is not null)
			{
				_unitOfWork.OperationVehicles.Remove(operationVehicle);
				await _unitOfWork.SaveAsync();
			}
		}

				
		public Task AddOrUpdate(OperationVehicle model)
        {
            throw new NotImplementedException();
        }
	}
}
