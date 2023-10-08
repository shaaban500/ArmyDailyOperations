using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.ViewModels.Operations;

namespace DailyOperations.Domain.Interfaces.Services.Operations
{
    public interface IOperatinSoldierServices: ICRUDServices<OperatinSoldier>
    {
		Task<OperatinSoldier> Add(GetAllOperationsViewModel model);
		Task<List<GroupedSoldierOperationsViewModel>> GetAll(long operationId);
		Task<List<OperatinSoldier>> Search(long soldierId, DateTime? dateFrom, DateTime? dateTo);
	}
}
