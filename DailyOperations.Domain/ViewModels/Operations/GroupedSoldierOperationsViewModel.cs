using DailyOperations.Domain.Entities;
using DailyOperations.Domain.Entities.Operations;

namespace DailyOperations.Domain.ViewModels.Operations
{
	public class GroupedSoldierOperationsViewModel
	{
        public OperationType OperationType { get; set; }
        public List<OperatinSoldier> OperatinSoldiers { get; set; }
    }
}
