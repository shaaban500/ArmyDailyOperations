using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Entities.Operations;

namespace DailyOperations.Domain.ViewModels.PoliceOfficers
{
    public class GetAllPoliceOfficersViewModel
    {
        // add
        public PowerType? PowerType { get; set; }
        public InnerDepartment InnerDepartment { get; set; }
        public GeneralDepartment GeneralDepartment { get; set; }
        public OfficerMilitaryDegree? OfficerMililaryDegree { get; set; }
        public PoliceOfficer? PoliceOfficer { get; set; }
        
        // dropdown lists
        public List<PoliceOfficer>? PoliceOfficers { get; set; }
        public List<OfficerMilitaryDegree>? OfficersMililaryDegrees { get; set; }
        public List<PowerType>? PowerTypes { get; set; }
        public List<GeneralDepartment>? GeneralDepartments { get; set; }
        public List<InnerDepartment>? InnerDepartments { get; set; }

        // to be selected
        public long SelectedOfficerAlternativeId { get; set; }
        public GetAllPoliceOfficersViewModel()
        {
            PowerTypes = new List<PowerType>();
            GeneralDepartments = new List<GeneralDepartment>();
            InnerDepartments = new List<InnerDepartment>();
            PoliceOfficers = new List<PoliceOfficer>();
            OfficersMililaryDegrees = new List<OfficerMilitaryDegree>();
        }


    }
}
