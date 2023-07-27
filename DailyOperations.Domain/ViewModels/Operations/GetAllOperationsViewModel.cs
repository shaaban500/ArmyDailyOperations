using DailyOperations.Domain.Entities;
using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Entities.Operations;

namespace DailyOperations.Domain.ViewModels.Operations
{
    public class GetAllOperationsViewModel
    {
		// table
        public DailyOperationViewModel DailyOperationViewModel { get; set; }

		// add 
		public GeneralDepartment GeneralDepartment { get; set; }
		public InnerDepartment InnerlDepartment { get; set; }
        public DailyOperation DailyOperation { get; set; }
        public ShiftType ShiftType { get; set; }
        public Sector Sector { get; set; }
        public SectorPlace SectorPlace { get; set; }

        public OperationType OperationType { get; set; }
        public OperationDescription OperationDescription { get; set; }
        public OperationInstruction OperationInstruction { get; set; }

        // dropdown lists


        public List<GeneralDepartment> GeneralDepartments { get; set; }
        public List<InnerDepartment> InnerDepartments { get; set; }
        public List<DailyOperation> DailyOperations { get; set; }
        public List<ShiftType> ShiftTypes { get; set; }
        public List<Sector> Sectors { get; set; }
        public List<SectorPlace> SectorPlaces { get; set; }
        public List<int> Times { get; set; }
        public List<PoliceOfficer> PoliceOfficers { get; set; }
        public List<PoliceAssistant> PoliceAssistants { get; set; }
        public List<Soldier> Soldiers { get; set; }
        public List<OperationType> OperationTypes { get; set; }
        public List<OperationDescription> OperationDescriptions { get; set; }
        public List<OperationInstruction> OperationInstructions { get; set; }
        public List<VehicleType> VehicleTypes { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        // need refctor
        public List<OperationOfficerViewModel> OperationOfficersViewModel { get; set; }
        public List<OperationAssistantViewModel> OperationAssistantsViewModel { get; set; }
        public List<OperationSoldierViewModel> OperationSoldiersViewModel { get; set; }
		public List<OperationVehicleViewModel> OperationVehiclesViewModel { get; set; }

		// selected IDs

		public long OperationId { get; set; }
        public DateTime Date { get; set; }
        public long GeneralDepartmentId { get; set; }
        public long InnerDepartmentId { get; set; }
        public long DailyOperationId { get; set; }
        public long ShiftTypeId { get; set; }
        public long SectorId { get; set; }
        public long SectorPlaceFromId { get; set; }
        public long SectorPlaceToId { get; set; }
        public int SelectedTimeFrom { get; set; }
        public int SelectedTimeTo { get; set; }
        public long PoliceOfficerId { get; set; }
        public long PoliceAssistantId { get; set; }
        public long SoldierId { get; set; }
        public long OperationTypeId { get; set; }
        public long OperationDescriptionId { get; set; }
        public long OperationInstructionId { get; set; }
        public long VehicleTypeId { get; set; }
        public long VehicleId { get; set; }
        public long DriverId { get; set; }
        public long DriverType { get; set; }
        public string DriverData { get; set; }
        public int OperationTimeFrom { get; set; }
        public int OperationTimeTo { get; set; }

        // search
        public DateTime? SearchDateFrom { get; set; }
        public DateTime? SearchDateTo { get; set; }
        public long MemberType { get; set; }

        public DateTime SelectedDateVehicleSearch { get; set; }

        public GetAllOperationsViewModel()
        {
            // table
            DailyOperationViewModel = new DailyOperationViewModel();
            OperationOfficersViewModel = new List<OperationOfficerViewModel>();
            OperationSoldiersViewModel = new List<OperationSoldierViewModel>();
            OperationAssistantsViewModel = new List<OperationAssistantViewModel>();

			// dropdown lists
			GeneralDepartments = new List<GeneralDepartment>();
            InnerDepartments = new List<InnerDepartment>();
            DailyOperations = new List<DailyOperation>();
            ShiftTypes = new List<ShiftType>();
            Sectors = new List<Sector>();
            SectorPlaces = new List<SectorPlace>();
            Times = new List<int>();
            PoliceOfficers = new List<PoliceOfficer>();
            PoliceAssistants = new List<PoliceAssistant>();
            Soldiers = new List<Soldier>();
            OperationTypes = new List<OperationType>();
            OperationDescriptions = new List<OperationDescription>();
            OperationInstructions = new List<OperationInstruction>();
            VehicleTypes = new List<VehicleType>();
            Vehicles = new List<Vehicle>();
        }
    }
}