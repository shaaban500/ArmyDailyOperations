using DailyOperations.Domain.Entities.Holidays;

namespace DailyOperations.Domain.ViewModels.SoldierHolidays
{
    public class SoldierHolidaysForPrintingViewModel
    {
        public List<SoldierHoliday> SoldierHolidays { get; set; }

        // for printing
        public string GeneralDepartment { get; set; }
        public string InnerDepartment { get; set; }
        public string SpecialInnerDepartment { get; set; }
        public string MilitaryDegree { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
    }
}
