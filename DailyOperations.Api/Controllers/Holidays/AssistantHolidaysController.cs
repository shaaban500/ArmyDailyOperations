using DailyOperations.Domain.Entities.Holidays;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Holidays;
using DailyOperations.Domain.ViewModels.AssistantHolidays;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Api.Controllers.Holidays
{
    public class AssistantHolidaysController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISeedAssistantHolidaysData _seedAssistantHolidaysData;
        public AssistantHolidaysController(IUnitOfWork unitOfWork, ISeedAssistantHolidaysData seedAssistantHolidaysData)
        {
            _unitOfWork = unitOfWork;
            _seedAssistantHolidaysData = seedAssistantHolidaysData;
        }

        public async Task<IActionResult> GetAll(GetAllAssistantHolidaysViewModel model)
        {
            var assistantHolidays = await _unitOfWork.AssistantHolidays.GetAllIQueryable();

            var notWantedHolidays = await _unitOfWork.AssistantHolidays.GetAllAsync(x =>
                                                   x.HolidayStartDate != null &&
                                                   x.HolidayEndDate != null &&
                                                   x.IsFinished != true);

            var result = await assistantHolidays
                                .Where(sh => sh.HolidayEndDate != null &&
                                             sh.HolidayStartDate != null && 
                                             sh.IsFinished == true &&
                                             !notWantedHolidays.Select(nwh => nwh.PoliceAssistantId).Contains(sh.PoliceAssistantId))
                                .Include(x => x.PoliceAssistant)
                                .GroupBy(sh => sh.PoliceAssistantId)
                                .Select(g => g.OrderByDescending(sh => sh.HolidayEndDate).FirstOrDefault())
                                .ToListAsync();


            var currentDate = DateTime.UtcNow.Date;

            if (model.NumberOfDays > 0)
            {
                result = result.Where(x => (currentDate - x.HolidayEndDate).Value.TotalDays == model.NumberOfDays).ToList();
            }

            foreach (var holiday in result)
            {
                var assistantHoliday = new AssistantHoliday
                {
                    Id = holiday.Id,
                    HolidayTypeId = holiday.Id,
                    PoliceAssistantId = holiday.PoliceAssistantId,
                    PoliceAssistant = holiday.PoliceAssistant,
                    HolidayStartDate = holiday.HolidayStartDate,
                    HolidayEndDate = holiday.HolidayEndDate,
                    HolidayType = holiday.HolidayType,
                    IsFinished = holiday.IsFinished,
                };

                var assistantHolidayViewModel = new AssistantHolidayViewModel
                {
                    PoliceAssistant = holiday.PoliceAssistant,
                    AssistantHoliday = assistantHoliday,
                    DaysSinceHoldiay = (currentDate - assistantHoliday.HolidayEndDate).Value.TotalDays,
                };

                model.AssistantHolidays.Add(assistantHolidayViewModel);
            }


            var holidayTypes = await _unitOfWork.HolidayTypes.GetAllAsync();
            model.HolidayTypes = holidayTypes.ToList();

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Add(GetAllAssistantHolidaysViewModel model)
        {
            var assistantHolidays = model.AssistantHolidays.Where(x => x.IsSelected == true).ToList();

            var allAssistantholidays = new List<AssistantHoliday>();

            foreach (var holiday in assistantHolidays)
            {
                var holidayToAdd = new AssistantHoliday
                {
                    PoliceAssistantId = holiday.PoliceAssistant.Id,
                    HolidayTypeId = model.SelectedHolidayTypeId,
                    HolidayStartDate = model.HolidayStartDate,
                    HolidayEndDate = model.HolidayEndDate,
                    IsFinished = false,
                };

                var IsReturned = await _unitOfWork.AssistantHolidays.GetByIdAsync(x => x.Id == holidayToAdd.PoliceAssistantId && x.IsFinished != true);

                if (IsReturned is null)
                {
                    var addedHoliday = await _unitOfWork.AssistantHolidays.AddAsync(holidayToAdd);

                    addedHoliday.PoliceAssistant = await _unitOfWork.PoliceAssistants.GetByIdAsync(addedHoliday.PoliceAssistantId);
                    allAssistantholidays.Add(addedHoliday);
                }
            }


            return View("HolidayPermessions", allAssistantholidays);
        }




        public async Task<IActionResult> GetAllHolidays(GetAllAssistantHolidaysViewModel model)
        {
            await _seedAssistantHolidaysData.SeedAssistantHolidays();

            var assistantHolidays = await _unitOfWork.AssistantHolidays.GetAllIQueryable();
            assistantHolidays = assistantHolidays.Where(x => !x.IsFinished).Include(x => x.PoliceAssistant).Include(x => x.HolidayType);

            assistantHolidays = model.ReturnDate != null ? assistantHolidays.Where(x => x.HolidayEndDate == model.ReturnDate) : assistantHolidays;

            var getAllAssistantHolidaysViewModel = new GetAllAssistantHolidaysViewModel();

            foreach (var holiday in assistantHolidays)
            {
                var assistantHoliday = new AssistantHoliday
                {
                    Id = holiday.Id,
                    HolidayTypeId = holiday.Id,
                    PoliceAssistantId = holiday.PoliceAssistantId,
                    PoliceAssistant = holiday.PoliceAssistant,
                    HolidayStartDate = holiday.HolidayStartDate,
                    HolidayEndDate = holiday.HolidayEndDate,
                    HolidayType = holiday.HolidayType,
                    IsFinished = holiday.IsFinished,
                };

                var assistantHolidayViewModel = new AssistantHolidayViewModel
                {
                    PoliceAssistant = holiday.PoliceAssistant,
                    AssistantHoliday = assistantHoliday,
                };

                getAllAssistantHolidaysViewModel.AssistantHolidays.Add(assistantHolidayViewModel);
            }

            return View(getAllAssistantHolidaysViewModel);
        }


        public async Task<IActionResult> EditReturnDates(GetAllAssistantHolidaysViewModel model)
        {
            var assistantHoliday = await _unitOfWork.AssistantHolidays.GetByIdAsync(model.AssistantHolidayId);

            if (assistantHoliday is not null)
            {
                assistantHoliday.HolidayStartDate = model.HolidayStartDate;
                assistantHoliday.HolidayEndDate = model.HolidayEndDate;

                await _unitOfWork.AssistantHolidays.UpdateAsync(assistantHoliday);
            }

            return RedirectToAction(nameof(GetAllHolidays));
        }



        public async Task<IActionResult> AddHolidayReturn(GetAllAssistantHolidaysViewModel model)
        {
            foreach (var holiday in model.AssistantHolidays.Where(x => x.IsSelectedForReturn == true))
            {
                var assistantHoliday = await _unitOfWork.AssistantHolidays.GetByIdAsync(holiday.AssistantHoliday.Id);

                if (assistantHoliday is not null && assistantHoliday.HolidayEndDate <= DateTime.UtcNow.Date)
                {
                    assistantHoliday.IsFinished = true;
                }

                await _unitOfWork.AssistantHolidays.UpdateAsync(assistantHoliday);
            }

            return RedirectToAction(nameof(GetAllHolidays));
        }

    }
}
