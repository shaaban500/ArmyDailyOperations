using DailyOperations.Domain.Entities.Holidays;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Holidays;
using DailyOperations.Domain.ViewModels.SoldierHolidays;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Api.Controllers.Holidays
{
    public class SoldierHolidaysController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISeedSoldierHolidaysData _seedSoldierHolidaysData;
        public SoldierHolidaysController(IUnitOfWork unitOfWork, ISeedSoldierHolidaysData seedSoldierHolidaysData)
        {
            _unitOfWork = unitOfWork;
            _seedSoldierHolidaysData = seedSoldierHolidaysData;
        }


        public async Task<IActionResult> GetAll(GetAllSoldierHolidaysViewModel model)
        {
            var soldierHolidays = await _unitOfWork.SoldierHolidays.GetAllIQueryable();


            var notWantedHolidays = await _unitOfWork.SoldierHolidays.GetAllAsync(x =>
                                                    x.HolidayStartDate != null &&
                                                    x.HolidayEndDate != null &&
                                                    x.IsFinished != true);


            var result = await soldierHolidays
                                .Where(sh => sh.HolidayEndDate != null &&
                                             sh.HolidayStartDate != null &&
                                             sh.IsFinished == true &&
                                             !notWantedHolidays.Select(nwh => nwh.SoldierId).Contains(sh.SoldierId))
                                .Include(x => x.Soldier)
                                .GroupBy(sh => sh.SoldierId)
                                .Select(g => g.OrderByDescending(sh => sh.HolidayEndDate).FirstOrDefault())
                                .ToListAsync();


            var currentDate = DateTime.UtcNow.Date;

            if (model.NumberOfDays > 0)
            {
                result = result.Where(x => (currentDate - x.HolidayEndDate).Value.TotalDays == model.NumberOfDays).ToList();
            }

            foreach (var holiday in result)
            {
                var soldierHoliday = new SoldierHoliday
                {
                    Id = holiday.Id,
                    HolidayTypeId = holiday.Id,
                    SoldierId = holiday.SoldierId,
                    Soldier = holiday.Soldier,
                    HolidayStartDate = holiday.HolidayStartDate,
                    HolidayEndDate = holiday.HolidayEndDate,
                    HolidayType = holiday.HolidayType,
                    IsFinished = holiday.IsFinished,
                };

                var soldierHolidayViewModel = new SoldierHolidayViewModel
                {
                    Soldier = holiday.Soldier,
                    SoldierHoliday = soldierHoliday,
                    DaysSinceHoldiay = (currentDate - soldierHoliday.HolidayEndDate).Value.TotalDays,
                };

                model.SoldierHolidays.Add(soldierHolidayViewModel);
            }


            var holidayTypes = await _unitOfWork.HolidayTypes.GetAllAsync();
            model.HolidayTypes = holidayTypes.ToList();

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Add(GetAllSoldierHolidaysViewModel model)
        {
            var soldierHolidays = model.SoldierHolidays.Where(x => x.IsSelected == true).ToList();

            var allSoldierholidays = new List<SoldierHoliday>();

            foreach (var holiday in soldierHolidays)
            {
                var holidayToAdd = new SoldierHoliday
                {
                    SoldierId = holiday.Soldier.Id,
                    HolidayTypeId = model.SelectedHolidayTypeId,
                    HolidayStartDate = model.HolidayStartDate,
                    HolidayEndDate = model.HolidayEndDate,
                    IsFinished = false,
                };

                var IsReturned = await _unitOfWork.SoldierHolidays.GetByIdAsync(x => x.Id == holidayToAdd.SoldierId && x.IsFinished != true);

                if (IsReturned is null)
                {
                    var addedHoliday = await _unitOfWork.SoldierHolidays.AddAsync(holidayToAdd);

                    addedHoliday.Soldier = await _unitOfWork.Soldiers.GetByIdAsync(addedHoliday.SoldierId);
                    allSoldierholidays.Add(addedHoliday);
                }
            }

            var soldierHolidayForPrinting = new SoldierHolidaysForPrintingViewModel
            {
                SoldierHolidays = allSoldierholidays,
                GeneralDepartment = model.GeneralDepartment,
                InnerDepartment = model.InnerDepartment,
                SpecialInnerDepartment = model.SpecialInnerDepartment,
                MilitaryDegree = model.MilitaryDegree,
                Name = model.Name,
                Job = model.Job
            };

            return View("HolidayPermessions", soldierHolidayForPrinting);
        }




        public async Task<IActionResult> GetAllHolidays(GetAllSoldierHolidaysViewModel model)
        {
            await _seedSoldierHolidaysData.SeedSoldierHolidays();

            var soldierHolidays = await _unitOfWork.SoldierHolidays.GetAllIQueryable();
            soldierHolidays = soldierHolidays.Where(x => !x.IsFinished).Include(x => x.Soldier).Include(x => x.HolidayType);

            soldierHolidays = model.ReturnDate != null ? soldierHolidays.Where(x => x.HolidayEndDate == model.ReturnDate) : soldierHolidays;

            var getAllSoldierHolidaysViewModel = new GetAllSoldierHolidaysViewModel();

            foreach (var holiday in soldierHolidays)
            {
                var soldierHoliday = new SoldierHoliday
                {
                    Id = holiday.Id,
                    HolidayTypeId = holiday.Id,
                    SoldierId = holiday.SoldierId,
                    Soldier = holiday.Soldier,
                    HolidayStartDate = holiday.HolidayStartDate,
                    HolidayEndDate = holiday.HolidayEndDate,
                    HolidayType = holiday.HolidayType,
                    IsFinished = holiday.IsFinished,
                };

                var soldierHolidayViewModel = new SoldierHolidayViewModel
                {
                    Soldier = holiday.Soldier,
                    SoldierHoliday = soldierHoliday,
                };

                getAllSoldierHolidaysViewModel.SoldierHolidays.Add(soldierHolidayViewModel);
            }

            return View(getAllSoldierHolidaysViewModel);
        }


        public async Task<IActionResult> EditReturnDates(GetAllSoldierHolidaysViewModel model)
        {
            var soldierHoliday = await _unitOfWork.SoldierHolidays.GetByIdAsync(model.SoldierHolidayId);

            if (soldierHoliday is not null)
            {
                soldierHoliday.HolidayStartDate = model.HolidayStartDate;
                soldierHoliday.HolidayEndDate = model.HolidayEndDate;

                await _unitOfWork.SoldierHolidays.UpdateAsync(soldierHoliday);
            }

            return RedirectToAction(nameof(GetAllHolidays));
        }



        public async Task<IActionResult> AddHolidayReturn(GetAllSoldierHolidaysViewModel model)
        {
            foreach (var holiday in model.SoldierHolidays.Where(x => x.IsSelectedForReturn == true))
            {
                var soldierHoliday = await _unitOfWork.SoldierHolidays.GetByIdAsync(holiday.SoldierHoliday.Id);

                if (soldierHoliday is not null && soldierHoliday.HolidayEndDate <= DateTime.UtcNow.Date)
                {
                    soldierHoliday.IsFinished = true;
                }

                await _unitOfWork.SoldierHolidays.UpdateAsync(soldierHoliday);
            }

            return RedirectToAction(nameof(GetAllHolidays));
        }



        public async Task<IActionResult> Delete(long id)
        {
            var holiday = await _unitOfWork.SoldierHolidays.GetByIdAsync(x => x.Id == id);

            if (holiday is not null)
            {
                _unitOfWork.SoldierHolidays.Remove(holiday);
                await _unitOfWork.SaveAsync();
            }

            return RedirectToAction(nameof(GetAllHolidays), null);
        }
    }
}
