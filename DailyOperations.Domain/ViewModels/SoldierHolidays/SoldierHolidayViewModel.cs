using DailyOperations.Domain.Entities;

namespace DailyOperations.Domain.ViewModels.SoldierHolidays
{
	public class SoldierHolidayViewModel
	{
        public Soldier Soldier { get; set; }
        public double DaysSinceHoldiay { get; set; }
        
    }
}
