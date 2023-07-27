using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Entities.Shared;

namespace DailyOperations.Domain.Entities
{
    public class Soldier : BaseEntity, IMember
    {
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(15)]
        public string? Phone { get; set; }

        public long? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        public long? PowerTypeId { get; set; }
        [ForeignKey("PowerTypeId")]
        public PowerType? PowerType { get; set; }

        public DateTime? RecruitmentStartDate{ get; set; }
        public DateTime? RecruitmentEndDate { get; set; }

        public long? EducationTypeId { get; set; }
        [ForeignKey("EducationTypeId")]
        public EducationType? EducationType { get; set; }

        public List<Skill>? Skills { get; set; }

    }
}
