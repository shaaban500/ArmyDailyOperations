using DailyOperations.Domain.Entities.Holidays;
using DailyOperations.Domain.Entities.Members;

namespace DailyOperations.Domain.ViewModels.OfficerHolidays
{
    public class OfficerHolidayViewModel
    {
        public PoliceOfficer PoliceOfficer { get; set; }
        public OfficerHoliday OfficerHoliday { get; set; }
        public double DaysSinceHoldiay { get; set; }

        public bool IsSelected { get; set; }
        public bool IsSelectedForReturn { get; set; }
    }
}
