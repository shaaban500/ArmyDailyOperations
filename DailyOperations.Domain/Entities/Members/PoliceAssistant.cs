using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.Entities.Shared;

namespace DailyOperations.Domain.Entities.Members
{
    public class PoliceAssistant : BaseEntity, IMember
    {
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(15)]
        public string? Phone { get; set; }

        public long? AssistantsMilitaryDegreeId { get; set; }
        [ForeignKey("AssistantsMilitaryDegreeId")]
        public AssistantsMilitaryDegree AssistantsMilitaryDegree { get; set; }

        public long? PowerTypeId { get; set; }
        [ForeignKey("PowerTypeId")]
        public PowerType? PowerType { get; set; }
        
        public long? GeneralDepartmentId { get; set; }
        public GeneralDepartment? GeneralDepartment { get; set; }

        public long? InnerDepartmentId { get; set; }
        public InnerDepartment? InnerDepartment { get; set; }
    }
}
