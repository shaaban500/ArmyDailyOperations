using System.Linq.Expressions;
using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Operations;
using DailyOperations.Domain.ViewModels.Operations;

namespace DailyOperations.Infrastructure.Services.Operations
{
	public class OperationPoliceAssistantServices : IOperationPoliceAssistantServices
	{
		private readonly IUnitOfWork _unitOfWork;
		public OperationPoliceAssistantServices(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperationPoliceAssistant> Add(GetAllOperationsViewModel model)
		{
			var operation = await _unitOfWork.Operations.GetByIdAsync(model.OperationId);

			if (operation is null)
			{
				return new OperationPoliceAssistant();
			}

			var existedOperationAssistant = await _unitOfWork.OperationPoliceAssistants.GetByIdAsync(null, x =>
			   x.PoliceAssistantId == model.PoliceAssistantId &&
			   x.Operation.Date == operation.Date);


			var exitedAssistantAsDriver = await _unitOfWork.OperationVehicles.GetByIdAsync(null, x =>
				x.DriverType == 2 &&
				x.DriverId == model.PoliceAssistantId 
				&& x.Operation.Date == operation.Date);


			if (existedOperationAssistant is not null || exitedAssistantAsDriver is not null)
			{
				return new OperationPoliceAssistant();
			}

			var operationAssistant = new OperationPoliceAssistant
			{
				OperationId = model.OperationId,
				OperationDescriptionId = model.OperationDescriptionId,
				OperationInstructionId = model.OperationInstructionId,
				OperationTypeId = model.OperationTypeId,
				PoliceAssistantId = model.PoliceAssistantId,
				TimeFrom = model.OperationTimeFrom == 0 ? operation.ShiftTimeFrom : model.OperationTimeFrom,
				TimeTo = model.OperationTimeTo == 0 ? operation.ShiftTimeTo : model.OperationTimeTo,
			};

			var addedOperationPoliceAssistant = await _unitOfWork.OperationPoliceAssistants.AddAsync(operationAssistant);

			return addedOperationPoliceAssistant;
		
		}

		public async Task<List<OperationPoliceAssistant>> GetAll(long operationId)
		{
			var operationAssistantsIncludes = new Expression<Func<OperationPoliceAssistant, object>>[]
			{
				p => p.OperationDescription,
				p => p.OperationInstruction,
				p => p.OperationType,
				p => p.PoliceAssistant,
				p => p.PoliceAssistant.AssistantsMilitaryDegree,
			};

			var operationAssistants = await _unitOfWork.OperationPoliceAssistants.GetAllAsync(x => x.OperationId == operationId, null, operationAssistantsIncludes);

			return operationAssistants.ToList();
		}
		
		public async Task Delete(long id)
		{
			var operationPoliceAssistant = await _unitOfWork.OperationPoliceAssistants.GetByIdAsync(id);

			if (operationPoliceAssistant != null)
			{
				_unitOfWork.OperationPoliceAssistants.Remove(operationPoliceAssistant);
				await _unitOfWork.SaveAsync();

				var operations = await _unitOfWork.OperationVehicles.GetAllAsync(x => x.RelatedOperationType == 2 && x.RelatedOperationId == id);

				foreach (var operation in operations)
				{
					_unitOfWork.OperationVehicles.Remove(operation);
				}

				await _unitOfWork.SaveAsync();
			}

		}
		
		public async Task<List<OperationPoliceAssistant>> Search(long assistantId, DateTime? dateFrom, DateTime? dateTo)
		{
			var operationAssistantsIncludes = new Expression<Func<OperationPoliceAssistant, object>>[]
			{
				p => p.PoliceAssistant,
				p => p.OperationType,
				p => p.OperationDescription,
				p => p.OperationInstruction,
				p => p.PoliceAssistant.PowerType,
				p => p.PoliceAssistant.Department,
				p => p.PoliceAssistant.AssistantsMilitaryDegree,
				operation => operation.Operation.DailyOperation,
				operation => operation.Operation.GeneralDepartment,
				operation => operation.Operation.InnerDepartment,
				operation => operation.Operation.InnerDepartment,
				operation => operation.Operation.Sector,
				operation => operation.Operation.SectorPlaceFrom,
				operation => operation.Operation.SectorPlaceTo,
				operation => operation.Operation.ShiftType,
			};

			var operationAssistants = await _unitOfWork.OperationPoliceAssistants.GetAllAsync(x => x.PoliceAssistantId == assistantId, null, operationAssistantsIncludes);

			if (dateFrom != null)
			{
				operationAssistants = operationAssistants.Where(x => x.Operation.Date >= dateFrom);
			}

			if (dateTo != null)
			{
				operationAssistants = operationAssistants.Where(x => x.Operation.Date <= dateTo);
			}

			return operationAssistants.ToList();
		}


		
		public Task AddOrUpdate(OperationPoliceAssistant model)
		{
			throw new NotImplementedException();
		}


		public async Task<List<OperationPoliceAssistant>> GetAll()
		{
			var operationPoliceAssistant = await _unitOfWork.OperationPoliceAssistants.GetAllAsync();
			return operationPoliceAssistant.ToList();
		}
	}
}
