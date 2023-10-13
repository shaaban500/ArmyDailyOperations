using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Entities.Shared;

namespace DailyOperations.Domain.Entities
{
	public class Soldier : BaseEntity
	{
		[MaxLength(100)]
		public string? Name { get; set; }
		[MaxLength(15)]
		public string? Phone { get; set; }

		public long? PowerTypeId { get; set; }
		[ForeignKey("PowerTypeId")]
		public PowerType? PowerType { get; set; }

		public DateTime? RecruitmentStartDate { get; set; }
		public DateTime? RecruitmentEndDate { get; set; }

		public long? EducationTypeId { get; set; }
		[ForeignKey("EducationTypeId")]
		public EducationType? EducationType { get; set; }

		public List<Skill>? Skills { get; set; }

		
		// current dept info
		public long? DepartmentId { get; set; }
		public Department? Department { get; set; }


		// prev dept info
		public long? PreviousDepartmentId { get; set; }
		public Department? PreviousDepartment { get; set; }

		
		// next dept info
		public long? CurrentDepartmentId { get; set; }
		public Department? CurrentDepartment { get; set; }
		public DateTime? MovingDate { get; set; }
		public string? MovingNotes { get; set; }

		
		// Fire Shooting Date
		public DateTime? LastFireShootingDate { get; set; }
	}
}