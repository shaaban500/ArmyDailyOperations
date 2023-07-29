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



        public async Task<IActionResult> GetAll(int numOfDays)
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

            if (numOfDays > 0)
            {
                soldierHolidayViewModels = soldierViewModels.Where(vm => vm.DaysSinceHoldiay == numOfDays).ToList();
            }

            var holidayTypes = await _unitOfWork.HolidayTypes.GetAllAsync();

            var getAllSoldierHolidaysViewModel = new GetAllSoldierHolidaysViewModel
            {
                SoldierHolidays = soldierHolidayViewModels,
                HolidayTypes = holidayTypes.ToList(),
            };

            return View(getAllSoldierHolidaysViewModel);
        }


    }
}
