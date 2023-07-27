using System.Linq.Expressions;
using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Operations;
using DailyOperations.Domain.ViewModels.Operations;

namespace DailyOperations.Infrastructure.Services.Operations
{
    public class OperationServices : IOperationServices
    {
        private readonly IUnitOfWork _unitOfWork;

		public OperationServices(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		public async Task<GetAllOperationsViewModel> AddorUpdate(GetAllOperationsViewModel model)
        {
            var existedOperation = await GetById(model);

            if (existedOperation is null)
            {
                var operation = new Operation
                {
                    GeneralDepartmentId = model.GeneralDepartmentId,
                    InnerDepartmentId = model.InnerDepartmentId,
                    DailyOperationId = model.DailyOperationId,
                    ShiftTypeId = model.ShiftTypeId,
                    SectorId = model.SectorId,
                    SectorPlaceFromId = model.SectorPlaceFromId,
                    SectorPlaceToId = model.SectorPlaceToId,
                    ShiftTimeFrom = model.SelectedTimeFrom,
                    ShiftTimeTo = model.SelectedTimeTo,
                    Date = model.Date,
                };

                var addedOperation = await _unitOfWork.Operations.AddAsync(operation);

                model.OperationId = addedOperation.Id;
            }
            else
            {
                model.OperationId = existedOperation.Id;
                model.DailyOperationViewModel.Operation = existedOperation;
            }

            return model;
        }

        public async Task<Operation> GetById(GetAllOperationsViewModel model)
        {
            Expression<Func<Operation, bool>> filter =
                operation => operation.GeneralDepartmentId == model.GeneralDepartmentId &&
                operation.InnerDepartmentId == model.InnerDepartmentId &&
                operation.DailyOperationId == model.DailyOperationId &&
                operation.ShiftTypeId == model.ShiftTypeId &&
                operation.SectorId == model.SectorId &&
                operation.SectorPlaceFromId == model.SectorPlaceFromId &&
                operation.SectorPlaceToId == model.SectorPlaceToId &&
                operation.ShiftTimeFrom == model.SelectedTimeFrom &&
                operation.ShiftTimeTo == model.SelectedTimeTo &&
                operation.Date == model.Date;
			
			var includes = new Expression<Func<Operation, object>>[]
			{
				operation => operation.DailyOperation,
				operation => operation.GeneralDepartment,
				operation => operation.InnerDepartment,
				operation => operation.InnerDepartment,
				operation => operation.Sector,
				operation => operation.SectorPlaceFrom,
				operation => operation.SectorPlaceTo,
				operation => operation.ShiftType,
			};

            var operation = await _unitOfWork.Operations.GetByIdAsync(model?.OperationId == 0 ? null : model?.OperationId, filter, includes);
            
			return operation;
        }


		public async Task<Operation> GetById(long operationId)
		{ 
			var includes = new Expression<Func<Operation, object>>[]
			{
				operation => operation.DailyOperation,
				operation => operation.GeneralDepartment,
				operation => operation.InnerDepartment,
				operation => operation.InnerDepartment,
				operation => operation.Sector,
				operation => operation.SectorPlaceFrom,
				operation => operation.SectorPlaceTo,
				operation => operation.ShiftType,
			};

			var operation = await _unitOfWork.Operations.GetByIdAsync(operationId, null, includes);

			return operation;
		}

		public Task AddOrUpdate(Operation model)
        {
            throw new NotImplementedException();
        }
        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

		public Task<List<Operation>> GetAll()
		{
			throw new NotImplementedException();
		}

	}
}
