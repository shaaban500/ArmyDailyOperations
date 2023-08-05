using DailyOperations.Domain.Entities.Holidays;

namespace DailyOperations.Domain.ViewModels.SoldierHolidays
{
    public class GetAllSoldierHolidaysViewModel
    {
        // filter number 
        public int NumberOfDays { get; set; }

        // table
        public List<SoldierHolidayViewModel> SoldierHolidays { get; set; }
        
        // dropdown list
        public List<HolidayType> HolidayTypes { get; set; }

        // edite 
        public DateTime HolidayStartDate { get; set; }
        public DateTime HolidayEndDate { get; set; }
        public long SoldierHolidayId { get; set; }
        public int Duration { get; set; }
        public long SelectedHolidayTypeId { get; set; }

        public DateTime? ReturnDate { get; set; }

        public GetAllSoldierHolidaysViewModel()
        {
            SoldierHolidays = new List<SoldierHolidayViewModel>();
            HolidayTypes = new List<HolidayType>();
        }
    }
}
