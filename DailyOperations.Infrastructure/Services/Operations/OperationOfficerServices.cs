using System.Linq.Expressions;
using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Operations;
using DailyOperations.Domain.ViewModels.Operations;

namespace DailyOperations.Infrastructure.Services.Operations
{
    public class OperationOfficerServices : IOperationOfficerServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public OperationOfficerServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

		public async Task<OperationOfficer> Add(GetAllOperationsViewModel model)
		{
			var operation = await _unitOfWork.Operations.GetByIdAsync(model.OperationId);
            
			if(operation is null)
			{
				return new OperationOfficer();
			}

			var existedOperationOfficer = await _unitOfWork.OperationOfficers.GetByIdAsync(null, x => 
				x.PoliceOfficerId == model.PoliceOfficerId &&
				x.Operation.Date == operation.Date);


			var exitedOfficerAsDriver = await _unitOfWork.OperationVehicles.GetByIdAsync(null, x =>
				x.DriverType == 1 &&
				x.DriverId == model.PoliceOfficerId &&
				x.Operation.Date == operation.Date);


			if(existedOperationOfficer is not null || exitedOfficerAsDriver is not null)
			{
				return new OperationOfficer();
			}

            var operationOfficer = new OperationOfficer
            {
                OperationId = model.OperationId,
                OperationDescriptionId = model.OperationDescriptionId,
                OperationInstructionId = model.OperationInstructionId,
                OperationTypeId = model.OperationTypeId,
                PoliceOfficerId = model.PoliceOfficerId,
                TimeFrom = model.OperationTimeFrom == 0 ?  operation.ShiftTimeFrom : model.OperationTimeFrom,
				TimeTo = model.OperationTimeTo == 0 ? operation.ShiftTimeTo : model.OperationTimeTo,
            };

            var addedOperationOfficer = await _unitOfWork.OperationOfficers.AddAsync(operationOfficer);
			
			return addedOperationOfficer;
        }

		public async Task<List<OperationOfficer>> GetAll(long operationId)
		{
			var operationOfficersIncludes = new Expression<Func<OperationOfficer, object>>[]
			{
				p => p.OperationDescription,
				p => p.OperationInstruction,
				p => p.OperationType,
				p => p.PoliceOfficer,
				p => p.PoliceOfficer.OfficerMilitaryDegree,
			};

			var operationOfficers = await _unitOfWork.OperationOfficers.GetAllAsync(x =>
				x.OperationId == operationId,
				x => x.OrderByDescending(a => a.PoliceOfficer.OfficerMilitaryDegree.DisplayOrder),
				operationOfficersIncludes);

            return operationOfficers.ToList();
		}
	
		public async Task Delete(long id)
        {
			var operationOfficer = await _unitOfWork.OperationOfficers.GetByIdAsync(id);
        
			if(operationOfficer != null) 
			{
				_unitOfWork.OperationOfficers.Remove(operationOfficer);
				await _unitOfWork.SaveAsync();
				
				var operations = await _unitOfWork.OperationVehicles.GetAllAsync(x => x.RelatedOperationType == 1 && x.RelatedOperationId == id);

				foreach(var operation in operations)
				{
					_unitOfWork.OperationVehicles.Remove(operation);
				}

				await _unitOfWork.SaveAsync();
			}

		}
		public Task AddOrUpdate(OperationOfficer model)
        {
            throw new NotImplementedException();
        }


        public async Task<List<OperationOfficer>> GetAll()
        {
            var operationOfficer = await _unitOfWork.OperationOfficers.GetAllAsync();
            return operationOfficer.ToList();
        }


		public async Task<List<OperationOfficer>> Search(long officerId, DateTime? dateFrom, DateTime? dateTo)
		{
			var operationOfficersIncludes = new Expression<Func<OperationOfficer, object>>[]
			{
				p => p.PoliceOfficer,
				p => p.OperationType,
				p => p.OperationDescription,
				p => p.OperationInstruction,
				p => p.PoliceOfficer.PowerType,
				p => p.PoliceOfficer.Department,
				p => p.PoliceOfficer.OfficerMilitaryDegree,
				operation => operation.Operation.DailyOperation,
				operation => operation.Operation.GeneralDepartment,
				operation => operation.Operation.InnerDepartment,
				operation => operation.Operation.InnerDepartment,
				operation => operation.Operation.Sector,
				operation => operation.Operation.SectorPlaceFrom,
				operation => operation.Operation.SectorPlaceTo,
				operation => operation.Operation.ShiftType,
			};

			var operationOfficers = await _unitOfWork.OperationOfficers.GetAllAsync(x => x.PoliceOfficerId == officerId, null, operationOfficersIncludes);

            if(dateFrom != null) 
            {
                operationOfficers = operationOfficers.Where(x => x.Operation.Date >= dateFrom);
            }

            if(dateTo != null) 
            {
                operationOfficers = operationOfficers.Where(x => x.Operation.Date <= dateTo);
			}

			return operationOfficers.ToList();
		}


        

	}
}
