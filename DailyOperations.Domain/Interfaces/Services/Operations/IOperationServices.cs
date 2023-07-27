using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.ViewModels.Operations;

namespace DailyOperations.Domain.Interfaces.Services.Operations
{
    public interface IOperationServices : ICRUDServices<Operation>
    {
		Task<GetAllOperationsViewModel> AddorUpdate(GetAllOperationsViewModel model);
		Task<Operation> GetById(GetAllOperationsViewModel model);
		Task<Operation> GetById(long operationId);
	}
}
