using DailyOperations.Domain.Entities.Holidays;
using DailyOperations.Domain.Entities.Members;

namespace DailyOperations.Domain.ViewModels.AssistantHolidays
{
    public class AssistantHolidayViewModel
    {
        public PoliceAssistant PoliceAssistant { get; set; }
        public AssistantHoliday AssistantHoliday { get; set; }
        public double DaysSinceHoldiay { get; set; }

        public bool IsSelected { get; set; }
        public bool IsSelectedForReturn { get; set; }
    }
}
