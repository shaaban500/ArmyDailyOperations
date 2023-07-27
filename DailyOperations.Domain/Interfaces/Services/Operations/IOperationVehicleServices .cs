using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.ViewModels.Operations;

namespace DailyOperations.Domain.Interfaces.Services.Operations
{
    public interface IOperationVehicleServices : ICRUDServices<OperationVehicle>
    {
		Task<OperationVehicle> Add(GetAllOperationsViewModel model, int operationType = 0, long relatedOperationId = 0);
		Task<List<OperationVehicleViewModel>> GetAll(long operationId);
		Task<List<OperationVehicleViewModel>> Search(DateTime date);
	}
}
