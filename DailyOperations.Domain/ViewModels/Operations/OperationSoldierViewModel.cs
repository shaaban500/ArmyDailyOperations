using DailyOperations.Domain.Entities.Operations;

namespace DailyOperations.Domain.ViewModels.Operations
{
	public class OperationSoldierViewModel
	{
		public OperatinSoldier OperatinSoldier { get; set; }
		public OperationVehicle OperationVehicle { get; set; }
        public string DriverName { get; set; }
    }
}
