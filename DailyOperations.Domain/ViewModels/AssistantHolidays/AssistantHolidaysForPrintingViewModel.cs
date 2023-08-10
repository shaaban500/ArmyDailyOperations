using DailyOperations.Domain.Entities.Holidays;

namespace DailyOperations.Domain.ViewModels.AssistantHolidays
{
    public class AssistantHolidaysForPrintingViewModel
    {
        public List<AssistantHoliday> AssistantHolidays { get; set; }

        // for printing
        public string GeneralDepartment { get; set; }
        public string InnerDepartment { get; set; }
        public string SpecialInnerDepartment { get; set; }
    }
}
