using DailyOperations.Domain.Entities.Holidays;

namespace DailyOperations.Domain.ViewModels.AssistantHolidays
{
    public class GetAllAssistantHolidaysViewModel
    {
        // filter number 
        public int NumberOfDays { get; set; }

        // table
        public List<AssistantHolidayViewModel> AssistantHolidays { get; set; }

        // dropdown list
        public List<HolidayType> HolidayTypes { get; set; }

        // edite 
        public DateTime HolidayStartDate { get; set; }
        public DateTime HolidayEndDate { get; set; }
        public long AssistantHolidayId { get; set; }
        public int Duration { get; set; }
        public long SelectedHolidayTypeId { get; set; }

        public DateTime? ReturnDate { get; set; }


        // for printing
        public string GeneralDepartment { get; set; }
        public string InnerDepartment { get; set; }
        public string SpecialInnerDepartment { get; set; }

        public GetAllAssistantHolidaysViewModel()
        {
            AssistantHolidays = new List<AssistantHolidayViewModel>();
            HolidayTypes = new List<HolidayType>();
        }
    }
}
