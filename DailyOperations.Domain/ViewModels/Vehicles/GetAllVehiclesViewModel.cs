using DailyOperations.Domain.Entities.Members;

namespace DailyOperations.Domain.ViewModels.Vehicles
{
    public class GetAllVehiclesViewModel
    {
        // add
        public Vehicle Vehicle { get; set; }
        public VehicleMark VehicleMark { get; set; }
        public VehicleType VehicleType { get; set; }
        
        // dropdow lists
        public List<Vehicle> Vehicles { get; set; }
        public List<VehicleMark> VehicleMarks { get; set; }
        public List<VehicleType> VehicleTypes { get; set; }

        public GetAllVehiclesViewModel()
        {
            Vehicles = new List<Vehicle>();
            VehicleMarks = new List<VehicleMark>();
            VehicleTypes = new List<VehicleType>();
        }
    }
}
