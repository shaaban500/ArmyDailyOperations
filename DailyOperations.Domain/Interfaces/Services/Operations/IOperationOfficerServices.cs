using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.ViewModels.Operations;

namespace DailyOperations.Domain.Interfaces.Services.Operations
{
    public interface IOperationOfficerServices : ICRUDServices<OperationOfficer>
    {
        Task<OperationOfficer> Add(GetAllOperationsViewModel model);
        Task<List<OperationOfficer>> GetAll(long operationId);
        Task<List<OperationOfficer>> Search(long officerId, DateTime? dateFrom, DateTime? dateTo);
	}
}
