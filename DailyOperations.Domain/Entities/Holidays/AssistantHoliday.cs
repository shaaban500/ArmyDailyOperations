using System.ComponentModel.DataAnnotations.Schema;
using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Entities.Shared;

namespace DailyOperations.Domain.Entities.Holidays
{
	public class AssistantHoliday : BaseEntity
	{
		public DateTime? HolidayStartDate { get; set; }
		public DateTime? HolidayEndDate { get; set; }
        public bool IsFinished { get; set; }

        public long PoliceAssistantId { get; set; }
		[ForeignKey("PoliceAssistantId")]
		public PoliceAssistant PoliceAssistant { get; set; }

		public long? HolidayTypeId { get; set; }
		[ForeignKey("HolidayTypeId")]
		public HolidayType? HolidayType { get; set; }
	}
}
