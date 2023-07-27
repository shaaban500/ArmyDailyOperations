using DailyOperations.Domain.Entities.Operations;

namespace DailyOperations.Domain.ViewModels.Operations
{
	public class DailyOperationViewModel
	{
		public Operation Operation { get; set; }
		public List<OperationOfficer>? OperationOfficers { get; set; }
		public List<OperationPoliceAssistant>? OperationPoliceAssistants { get; set; }
		public List<OperatinSoldier>? OperatinSoldiers { get; set; }
		public List<OperationVehicle>? OperationVehicles { get; set; }

		public DailyOperationViewModel()
		{
			Operation = new Operation();
			OperationOfficers = new List<OperationOfficer>();
			OperationPoliceAssistants = new List<OperationPoliceAssistant>();
			OperatinSoldiers = new List<OperatinSoldier>();
			OperationVehicles = new List<OperationVehicle>();
		}
	}
}
