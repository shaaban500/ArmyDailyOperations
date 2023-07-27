
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DailyOperations.Domain.Entities.Shared;

namespace DailyOperations.Domain.Entities.Members
{
    public class PoliceOfficer : BaseEntity, IMember
    {
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(15)]
        public string? Phone { get; set; }

        public long? OfficerMilitaryDegreeId { get; set; }
        [ForeignKey("OfficerMilitaryDegreeId")]
        public OfficerMilitaryDegree OfficerMilitaryDegree { get; set; }

        public long? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        public long? PowerTypeId { get; set; }
        [ForeignKey("PowerTypeId")]
        public PowerType? PowerType { get; set; }

    }
}
