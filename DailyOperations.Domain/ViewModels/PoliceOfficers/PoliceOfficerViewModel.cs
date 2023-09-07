using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Entities.Operations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DailyOperations.Domain.ViewModels.PoliceOfficers
{
	public class PoliceOfficerViewModel
	{
        public long Id { get; set; }

        [MaxLength(100)]
		public string? Name { get; set; }
		[MaxLength(15)]
		public string? Phone { get; set; }

		public long? OfficerMilitaryDegreeId { get; set; }
		[ForeignKey("OfficerMilitaryDegreeId")]
		public OfficerMilitaryDegree OfficerMilitaryDegree { get; set; }

		public long? PowerTypeId { get; set; }
		[ForeignKey("PowerTypeId")]
		public PowerType? PowerType { get; set; }

		public long? GeneralDepartmentId { get; set; }
		public GeneralDepartment? GeneralDepartment { get; set; }

		public long? InnerDepartmentId { get; set; }
		public InnerDepartment? InnerDepartment { get; set; }

		public bool IsArmed { get; set; }
		public bool IsInadministrativeWork { get; set; }


		public long? PoliceOfficerAlternativeId { get; set; }
		[ForeignKey("PoliceOfficerAlternativeId")]
		public PoliceOfficer? PoliceOfficerAlternative { get; set; }

        public int Count { get; set; }
    }
}
