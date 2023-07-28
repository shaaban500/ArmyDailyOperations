using DailyOperations.Domain.Entities.Members;
using System.ComponentModel.DataAnnotations.Schema;
using DailyOperations.Domain.Entities.Shared;

namespace DailyOperations.Domain.Entities.Holidays
{
	public class SoldierHoliday : BaseEntity
	{
		public DateTime HolidayStartDate { get; set; }
		public int Duration { get; set; }
		// need refactor, because this is a derived attribute
		public DateTime HolidayEndDate { get; set; }
		public bool IsFinished { get; set; }

		public long SoldierId { get; set; }
		[ForeignKey("SoldierId")]
		public Soldier Soldier { get; set; }

		public long HolidayTypeId { get; set; }
		[ForeignKey("HolidayTypeId")]
		public HolidayType HolidayType { get; set; }

	}
}
