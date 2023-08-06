using DailyOperations.Domain.Entities.Holidays;

namespace DailyOperations.Domain.ViewModels.OfficerHolidays
{
    public class GetAllOfficerHolidaysViewModel
    {
        // filter number 
        public int NumberOfDays { get; set; }

        // table
        public List<OfficerHolidayViewModel> OfficerHolidays { get; set; }

        // dropdown list
        public List<HolidayType> HolidayTypes { get; set; }

        // edite 
        public DateTime HolidayStartDate { get; set; }
        public DateTime HolidayEndDate { get; set; }
        public long OfficerHolidayId { get; set; }
        public int Duration { get; set; }
        public long SelectedHolidayTypeId { get; set; }

        public DateTime? ReturnDate { get; set; }

        public GetAllOfficerHolidaysViewModel()
        {
            OfficerHolidays = new List<OfficerHolidayViewModel>();
            HolidayTypes = new List<HolidayType>();
        }
    }
}
