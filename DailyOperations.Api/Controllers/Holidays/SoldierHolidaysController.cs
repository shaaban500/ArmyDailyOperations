using DailyOperations.Domain.Entities.Holidays;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.ViewModels.SoldierHolidays;
using Microsoft.AspNetCore.Mvc;

namespace DailyOperations.Api.Controllers.Holidays
{
	public class SoldierHolidaysController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public SoldierHolidaysController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

        //public async Task<IActionResult> GetAll(int numOfDays)
        //{

        //	var soldierHolidays = await _unitOfWork.SoldierHolidays.GetAllIQueryable();

        //	var today = DateTime.UtcNow.Date;

        //	var soldierHolidayViewModels = soldierHolidays
        //			.Where(h => h.IsFinished)
        //			.GroupBy(h => h.SoldierId)
        //			.Select(g => new SoldierHolidayViewModel
        //			{
        //				Soldier = g.OrderByDescending(h => h.HolidayEndDate).First().Soldier,
        //				DaysSinceHoldiay = (today - g.OrderByDescending(h => h.HolidayEndDate).First().HolidayEndDate.Date).TotalDays
        //			});


        //	if(numOfDays > 0)
        //	{
        //		soldierHolidayViewModels = soldierHolidayViewModels.Where(vm => vm.DaysSinceHoldiay == numOfDays);
        //          }


        //	var holidayTypes = await _unitOfWork.HolidayTypes.GetAllAsync();

        //          var getAllSoldierHolidaysViewModel = new GetAllSoldierHolidaysViewModel
        //	{
        //              SoldierHolidays = soldierHolidayViewModels.ToList(),
        //		HolidayTypes = holidayTypes.ToList(),
        //          };

        //          return View(getAllSoldierHolidaysViewModel);
        //}



        public async Task<IActionResult> GetAll(GetAllSoldierHolidaysViewModel model)
        {
            var soldiers = await _unitOfWork.Soldiers.GetAllIQueryable();

            var soldierViewModels = soldiers
                .Select(soldier => new SoldierHolidayViewModel
                {
                    Soldier = soldier,
                    DaysSinceHoldiay = 0
                })
                .ToList();

            var soldierHolidays = await _unitOfWork.SoldierHolidays.GetAllIQueryable();

            var today = DateTime.UtcNow.Date;

            foreach (var soldierHoliday in soldierHolidays)
            {
                if (soldierHoliday.IsFinished)
                {
                    var soldierViewModel = soldierViewModels.FirstOrDefault(vm => vm.Soldier.Id == soldierHoliday.SoldierId);
                    if (soldierViewModel != null)
                    {
                        var daysSinceHoliday = (today - soldierHoliday.HolidayEndDate.Date).TotalDays;
                        if (daysSinceHoliday < 0)
                        {
                            daysSinceHoliday = 0;
                        }
                        soldierViewModel.DaysSinceHoldiay = daysSinceHoliday;
                    }
                }
            }

            var soldierHolidayViewModels = soldierViewModels;

            if (model.NumberOfDays > 0)
            {
                soldierHolidayViewModels = soldierViewModels.Where(vm => vm.DaysSinceHoldiay == model.NumberOfDays).ToList();
            }

            var holidayTypes = await _unitOfWork.HolidayTypes.GetAllAsync();

            var getAllSoldierHolidaysViewModel = new GetAllSoldierHolidaysViewModel
            {
                SoldierHolidays = soldierHolidayViewModels,
                HolidayTypes = holidayTypes.ToList(),
            };

            return View(getAllSoldierHolidaysViewModel);
        }



        [HttpPost]
        public async Task<IActionResult> Add(GetAllSoldierHolidaysViewModel model)
        {
            var soldierHolidays = model.SoldierHolidays.Where(x => x.IsSelected == true).ToList();

            foreach (var holiday in soldierHolidays)
            {
                var holidayToAdd = new SoldierHoliday
                {
                    SoldierId = holiday.Soldier.Id,
                    HolidayTypeId = model.SelectedHolidayTypeId,
                    HolidayStartDate = model.HolidayStartDate,
                    HolidayEndDate = model.HolidayEndDate,
                    Duration = model.Duration,
                    IsFinished = false,
                };

                var addedHoliday = await _unitOfWork.SoldierHolidays.AddAsync(holidayToAdd);
            }


            return RedirectToAction(nameof(GetAll));
        }


        [HttpPost]
        public async Task<IActionResult> GetAllHolidays()
        {
            return RedirectToAction(nameof(GetAll));

        }
    }
}
