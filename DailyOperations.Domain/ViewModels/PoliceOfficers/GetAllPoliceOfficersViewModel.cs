using DailyOperations.Domain.Entities.Members;

namespace DailyOperations.Domain.ViewModels.PoliceOfficers
{
    public class GetAllPoliceOfficersViewModel
    {
        // add
        public PowerType? PowerType { get; set; }
        public Department? Department { get; set; }
        public OfficerMilitaryDegree? OfficerMililaryDegree { get; set; }
        public PoliceOfficer? PoliceOfficer { get; set; }
        
        // dropdown lists
        public List<PoliceOfficer>? PoliceOfficers { get; set; }
        public List<OfficerMilitaryDegree>? OfficersMililaryDegrees { get; set; }
        public List<PowerType>? PowerTypes { get; set; }
        public List<Department>? Departments { get; set; }

        public GetAllPoliceOfficersViewModel()
        {
            PowerTypes = new List<PowerType>();
            Departments = new List<Department>();
            PoliceOfficers = new List<PoliceOfficer>();
            OfficersMililaryDegrees = new List<OfficerMilitaryDegree>();
        }


    }
}
