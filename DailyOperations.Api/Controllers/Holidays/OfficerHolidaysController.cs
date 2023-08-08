using DailyOperations.Domain.Entities.Holidays;
using DailyOperations.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DailyOperations.Domain.ViewModels.OfficerHolidays;
using DailyOperations.Domain.Interfaces.Services.Holidays;

namespace DailyOperations.Api.Controllers.Holidays
{
    public class OfficerHolidaysController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISeedOfficerHolidaysData _seedOfficerHolidaysData;
        public OfficerHolidaysController(IUnitOfWork unitOfWork, ISeedOfficerHolidaysData seedOfficerHolidaysData)
        {
            _unitOfWork = unitOfWork;
            _seedOfficerHolidaysData = seedOfficerHolidaysData;
        }


        public async Task<IActionResult> GetAll(GetAllOfficerHolidaysViewModel model)
        {
            var officerHolidays = await _unitOfWork.OfficerHolidays.GetAllIQueryable();

            var notWantedHolidays = await _unitOfWork.OfficerHolidays.GetAllAsync(x =>
                                                   x.HolidayStartDate != null &&
                                                   x.HolidayEndDate != null &&
                                                   x.IsFinished != true);

            var result = await officerHolidays
                                .Include(x => x.PoliceOfficer)
                                .Where(sh => sh.HolidayEndDate != null &&
                                             sh.HolidayStartDate != null &&
                                             sh.IsFinished == true &&
                                             !notWantedHolidays.Select(nwh => nwh.PoliceOfficerId).Contains(sh.PoliceOfficerId))
                                .GroupBy(sh => sh.PoliceOfficerId)
                                .Select(g => g.OrderByDescending(sh => sh.HolidayEndDate).FirstOrDefault())
                                .ToListAsync();

            var currentDate = DateTime.UtcNow.Date;

            if (model.NumberOfDays > 0)
            {
                result = result.Where(x => (currentDate - x.HolidayEndDate).Value.TotalDays == model.NumberOfDays).ToList();
            }

            foreach (var holiday in result)
            {
                var officerHoliday = new OfficerHoliday
                {
                    Id = holiday.Id,
                    HolidayTypeId = holiday.Id,
                    PoliceOfficerId = holiday.PoliceOfficerId,
                    PoliceOfficer = holiday.PoliceOfficer,
                    HolidayStartDate = holiday.HolidayStartDate,
                    HolidayEndDate = holiday.HolidayEndDate,
                    HolidayType = holiday.HolidayType,
                    IsFinished = holiday.IsFinished,
                };

                var officerHolidayViewModel = new OfficerHolidayViewModel
                {
                    PoliceOfficer = holiday.PoliceOfficer,
                    OfficerHoliday = officerHoliday,
                    DaysSinceHoldiay = (currentDate - officerHoliday.HolidayEndDate).Value.TotalDays,
                };

                model.OfficerHolidays.Add(officerHolidayViewModel);
            }


            var holidayTypes = await _unitOfWork.HolidayTypes.GetAllAsync();
            model.HolidayTypes = holidayTypes.ToList();

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Add(GetAllOfficerHolidaysViewModel model)
        {
            var officerHolidays = model.OfficerHolidays.Where(x => x.IsSelected == true).ToList();

            var allOfficerholidays = new List<OfficerHoliday>();

            foreach (var holiday in officerHolidays)
            {
                var holidayToAdd = new OfficerHoliday
                {
                    PoliceOfficerId = holiday.PoliceOfficer.Id,
                    HolidayTypeId = model.SelectedHolidayTypeId,
                    HolidayStartDate = model.HolidayStartDate,
                    HolidayEndDate = model.HolidayEndDate,
                    IsFinished = false,
                };

                var IsReturned = await _unitOfWork.OfficerHolidays.GetByIdAsync(x => x.Id == holidayToAdd.PoliceOfficerId && x.IsFinished != true);

                if(IsReturned is null)
                {
                    var addedHoliday = await _unitOfWork.OfficerHolidays.AddAsync(holidayToAdd);

                    addedHoliday.PoliceOfficer = await _unitOfWork.PoliceOfficers.GetByIdAsync(addedHoliday.PoliceOfficerId);
                    allOfficerholidays.Add(addedHoliday);
                }
            }

            return View("HolidayPermessions", allOfficerholidays);
        }




        public async Task<IActionResult> GetAllHolidays(GetAllOfficerHolidaysViewModel model)
        {
            await _seedOfficerHolidaysData.SeedOfficerHolidays();

            var officerHolidays = await _unitOfWork.OfficerHolidays.GetAllIQueryable();
            officerHolidays = officerHolidays.Where(x => !x.IsFinished).Include(x => x.PoliceOfficer).Include(x => x.HolidayType);

            officerHolidays = model.ReturnDate != null ? officerHolidays.Where(x => x.HolidayEndDate == model.ReturnDate) : officerHolidays;

            var getAllOfficerHolidaysViewModel = new GetAllOfficerHolidaysViewModel();

            foreach (var holiday in officerHolidays)
            {
                var officerHoliday = new OfficerHoliday
                {
                    Id = holiday.Id,
                    HolidayTypeId = holiday.Id,
                    PoliceOfficerId = holiday.PoliceOfficerId,
                    PoliceOfficer = holiday.PoliceOfficer,
                    HolidayStartDate = holiday.HolidayStartDate,
                    HolidayEndDate = holiday.HolidayEndDate,
                    HolidayType = holiday.HolidayType,
                    IsFinished = holiday.IsFinished,
                };

                var officerHolidayViewModel = new OfficerHolidayViewModel
                {
                    PoliceOfficer = holiday.PoliceOfficer,
                    OfficerHoliday = officerHoliday,
                };

                getAllOfficerHolidaysViewModel.OfficerHolidays.Add(officerHolidayViewModel);
            }

            return View(getAllOfficerHolidaysViewModel);
        }


        public async Task<IActionResult> EditReturnDates(GetAllOfficerHolidaysViewModel model)
        {
            var officerHoliday = await _unitOfWork.OfficerHolidays.GetByIdAsync(model.OfficerHolidayId);

            if (officerHoliday is not null)
            {
                officerHoliday.HolidayStartDate = model.HolidayStartDate;
                officerHoliday.HolidayEndDate = model.HolidayEndDate;

                await _unitOfWork.OfficerHolidays.UpdateAsync(officerHoliday);
            }

            return RedirectToAction(nameof(GetAllHolidays));
        }



        public async Task<IActionResult> AddHolidayReturn(GetAllOfficerHolidaysViewModel model)
        {
            foreach (var holiday in model.OfficerHolidays.Where(x => x.IsSelectedForReturn == true))
            {
                var officerHoliday = await _unitOfWork.OfficerHolidays.GetByIdAsync(holiday.OfficerHoliday.Id);

                if (officerHoliday is not null && officerHoliday.HolidayEndDate <= DateTime.UtcNow.Date)
                {
                    officerHoliday.IsFinished = true;
                }

                await _unitOfWork.OfficerHolidays.UpdateAsync(officerHoliday);
            }

            return RedirectToAction(nameof(GetAllHolidays));
        }

    }
}
