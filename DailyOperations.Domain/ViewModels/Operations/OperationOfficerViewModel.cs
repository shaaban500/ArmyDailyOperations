using DailyOperations.Domain.Entities.Operations;

namespace DailyOperations.Domain.ViewModels.Operations
{
	public class OperationOfficerViewModel
	{
        public OperationOfficer OperationOfficer { get; set; }
        public OperationVehicle OperationVehicle { get; set; }
        public string DriverName { get; set; }
    }
}
