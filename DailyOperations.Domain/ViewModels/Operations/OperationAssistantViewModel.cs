using DailyOperations.Domain.Entities.Operations;

namespace DailyOperations.Domain.ViewModels.Operations
{
	public class OperationAssistantViewModel
	{
		public OperationPoliceAssistant OperationPoliceAssistant { get; set; }
		public OperationVehicle OperationVehicle { get; set; }
        public string DriverName { get; set; }
    }
}
