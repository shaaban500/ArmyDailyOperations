using DailyOperations.Domain.Entities.Holidays;

namespace DailyOperations.Domain.ViewModels.OfficerHolidays
{
    public class OfficerHolidaysForPrintingViewModel
    {
        public List<OfficerHoliday> OfficerHolidays { get; set; }

        // for printing
        public string GeneralDepartment { get; set; }
        public string InnerDepartment { get; set; }
        public string SpecialInnerDepartment { get; set; }
    }
}
