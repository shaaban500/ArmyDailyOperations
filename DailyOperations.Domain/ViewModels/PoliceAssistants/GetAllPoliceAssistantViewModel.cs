using DailyOperations.Domain.Entities.Members;

namespace DailyOperations.Domain.ViewModels.PoliceAssistants
{
    public class GetAllPoliceAssistantViewModel
    {
        // add
        public PowerType PowerType { get; set; }
        public Department Department { get; set; }
        public AssistantsMilitaryDegree AssistantMililaryDegree { get; set; }
        public PoliceAssistant PoliceAssistant { get; set; }

        // dropdown lists
        public List<PoliceAssistant> policeAssistants { get; set; }
        public List<AssistantsMilitaryDegree> AssistantsMilitaryDegrees { get; set; }
        public List<PowerType> PowerTypes { get; set; }
        public List<Department> Departments { get; set; }

        public GetAllPoliceAssistantViewModel()
        {
            PowerTypes = new List<PowerType>();
            Departments = new List<Department>();
            policeAssistants = new List<PoliceAssistant>();
            AssistantsMilitaryDegrees = new List<AssistantsMilitaryDegree>();
        }
    }
}
