using DailyOperations.Domain.Interfaces;
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
			//if(numOfDays > 0) 
			//{ 
			//	var soldiers = await _unitOfWork.SoldierHolidays.GetAllIQueryable();

			//	var today = DateTime.UtcNow.Date;

			//	var officerViewModels = soldiers
			//			.Where(h => h.IsFinished)
			//			.GroupBy(h => h.SoldierId)
			//			.Select(g => new SoldierViewModel
			//			{
			//				Soldier = g.OrderByDescending(h => h.HolidayEndDate).First().Soldier,
			//				DaysSinceHoliday = (today - g.OrderByDescending(h => h.HolidayEndDate).First().HolidayEndDate.Date).TotalDays
			//			})
			//			.ToList();


			//}
			//else 
			//{
				
			//}
			return View();
		}


	}
}
