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

		public async Task<IActionResult> GetAll(int numOfDays)
		{

			var soldierHolidays = await _unitOfWork.SoldierHolidays.GetAllIQueryable();

			var today = DateTime.UtcNow.Date;

			var soldierHolidayViewModels = soldierHolidays
					.Where(h => h.IsFinished)
					.GroupBy(h => h.SoldierId)
					.Select(g => new SoldierHolidayViewModel
					{
						Soldier = g.OrderByDescending(h => h.HolidayEndDate).First().Soldier,
						DaysSinceHoldiay = (today - g.OrderByDescending(h => h.HolidayEndDate).First().HolidayEndDate.Date).TotalDays
					});


			if(numOfDays > 0)
			{
				soldierHolidayViewModels = soldierHolidayViewModels.Where(vm => vm.DaysSinceHoldiay == numOfDays);
			}


			return View(new GetAllSoldierHolidaysViewModel { SoldierHolidays = soldierHolidayViewModels.ToList() });
		}






	}
}
