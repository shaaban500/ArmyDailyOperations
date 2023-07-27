using DailyOperations.Domain.Entities.Operations;

namespace DailyOperations.Domain.ViewModels.Operations
{
	public class OperationVehicleViewModel
	{
        public OperationVehicle OperationVehicle { get; set; }
        public string? DriverName { get; set; }
        public string? OfficerName { get; set; }
    }
}
