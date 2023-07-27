using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.ViewModels.Operations;

namespace DailyOperations.Domain.Interfaces.Services.Operations
{
    public interface IOperationPoliceAssistantServices : ICRUDServices<OperationPoliceAssistant>
    {
		Task<OperationPoliceAssistant> Add(GetAllOperationsViewModel model);
		Task<List<OperationPoliceAssistant>> GetAll(long operationId);
		Task<List<OperationPoliceAssistant>> Search(long assistantId, DateTime? dateFrom, DateTime? dateTo);
	}
}
