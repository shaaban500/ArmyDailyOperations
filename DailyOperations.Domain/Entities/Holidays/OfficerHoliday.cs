using System.ComponentModel.DataAnnotations.Schema;
using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Entities.Shared;

namespace DailyOperations.Domain.Entities.Holidays
{
	public class OfficerHoliday : BaseEntity
	{
		public DateTime? HolidayStartDate { get; set; }
		public DateTime? HolidayEndDate { get; set; }
		public bool IsFinished { get; set; }

		public long PoliceOfficerId { get; set; }
		[ForeignKey("PoliceOfficerId")]
		public PoliceOfficer PoliceOfficer { get; set; }

		public long? HolidayTypeId { get; set; }
		[ForeignKey("HolidayTypeId")]
		public HolidayType? HolidayType { get; set; }

	}
}
