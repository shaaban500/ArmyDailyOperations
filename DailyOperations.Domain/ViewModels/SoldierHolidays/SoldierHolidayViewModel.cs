using DailyOperations.Domain.Entities;
using DailyOperations.Domain.Entities.Holidays;

namespace DailyOperations.Domain.ViewModels.SoldierHolidays
{
	public class SoldierHolidayViewModel
	{
        public Soldier Soldier { get; set; }
        public SoldierHoliday SoldierHoliday { get; set; }
        public double DaysSinceHoldiay { get; set; }

        public bool IsSelected { get; set; }
        public bool IsSelectedForReturn { get; set; }
    }
}
