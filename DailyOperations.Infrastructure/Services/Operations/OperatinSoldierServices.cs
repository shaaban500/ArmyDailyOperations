using System.Linq.Expressions;
using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Operations;
using DailyOperations.Domain.ViewModels.Operations;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Infrastructure.Services.Operations
{
	public class OperatinSoldierServices : IOperatinSoldierServices
	{
		private readonly IUnitOfWork _unitOfWork;
		public OperatinSoldierServices(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<OperatinSoldier> Add(GetAllOperationsViewModel model)
		{
			var operation = await _unitOfWork.Operations.GetByIdAsync(model.OperationId);

			if (operation is null)
			{
				return new OperatinSoldier();
			}

			var existedOperationSoldier = await _unitOfWork.OperationSoldiers.GetByIdAsync(null, x =>
				  x.SoldierId == model.SoldierId &&
				  x.Operation.Date == operation.Date);


			var exitedSoldierAsDriver = await _unitOfWork.OperationVehicles.GetByIdAsync(null, x =>
					x.DriverType == 3 &&
					x.DriverId == model.SoldierId &&
					x.Operation.Date == operation.Date);


			if (existedOperationSoldier is not null || exitedSoldierAsDriver is not null)
			{
				return new OperatinSoldier();
			}

			var operationSoldier = new OperatinSoldier
			{
				OperationId = model.OperationId,
				OperationDescriptionId = model.OperationDescriptionId,
				OperationTypeId = model.OperationTypeId,
				SoldierId = model.SoldierId,
			};

			var addedOperationSoldier = await _unitOfWork.OperationSoldiers.AddAsync(operationSoldier);

			return addedOperationSoldier;
		}

		public async Task<List<GroupedSoldierOperationsViewModel>> GetAll(long operationId)
		{
			var operationSoldiersIncludes = new Expression<Func<OperatinSoldier, object>>[]
			{
				p => p.OperationDescription,
				p => p.OperationType,
				p => p.Soldier,
			};

			var operationSoldiers = await _unitOfWork.OperationSoldiers.GetAllAsync(x => x.OperationId == operationId, null, operationSoldiersIncludes);

			// grouping by operation type

			var operationSoldiersList = await operationSoldiers.ToListAsync();
			var operationTypes = operationSoldiersList.Select(x => x.OperationType).Distinct();
			
			var groupedSoldierOperations = new List<GroupedSoldierOperationsViewModel>();

			foreach(var operationType in operationTypes)
			{
				var operationSoldierModel = new GroupedSoldierOperationsViewModel
				{
					OperationType = operationType,
					OperatinSoldiers = new List<OperatinSoldier>()
				};
				
				foreach (var operation in operationSoldiersList.Where(x => x.OperationTypeId == operationType.Id))
				{
					operationSoldierModel.OperatinSoldiers.Add(operation);
				}

				groupedSoldierOperations.Add(operationSoldierModel);
			}

			return groupedSoldierOperations;
		}

		public async Task<List<OperatinSoldier>> Search(long soldierId, DateTime? dateFrom, DateTime? dateTo)
		{
			var operationSoldiersIncludes = new Expression<Func<OperatinSoldier, object>>[]
			{
				p => p.Soldier,
				p => p.OperationType,
				p => p.OperationDescription,
				p => p.Soldier.PowerType,
				p => p.Soldier.Department,
				operation => operation.Operation.DailyOperation,
				operation => operation.Operation.GeneralDepartment,
				operation => operation.Operation.InnerDepartment,
				operation => operation.Operation.InnerDepartment,
				operation => operation.Operation.Sector,
				operation => operation.Operation.SectorPlaceFrom,
				operation => operation.Operation.SectorPlaceTo,
				operation => operation.Operation.ShiftType,
			};

			var operationSoldiers = await _unitOfWork.OperationSoldiers.GetAllAsync(x => x.SoldierId == soldierId, null, operationSoldiersIncludes);

			if (dateFrom != null)
			{
				operationSoldiers = operationSoldiers.Where(x => x.Operation.Date >= dateFrom);
			}

			if (dateTo != null)
			{
				operationSoldiers = operationSoldiers.Where(x => x.Operation.Date <= dateTo);
			}

			return operationSoldiers.ToList();
		}

		public async Task Delete(long id)
		{
			var operationSoldier = await _unitOfWork.OperationSoldiers.GetByIdAsync(id);

			if (operationSoldier != null)
			{
				_unitOfWork.OperationSoldiers.Remove(operationSoldier);
				await _unitOfWork.SaveAsync();
			}
		}

		public Task AddOrUpdate(OperatinSoldier model)
		{
			throw new NotImplementedException();
		}


		public async Task<List<OperatinSoldier>> GetAll()
		{
			var operationSoldiers = await _unitOfWork.OperationSoldiers.GetAllAsync();
			return operationSoldiers.ToList();
		}

	}
}