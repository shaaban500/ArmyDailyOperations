using DailyOperations.Domain.Entities.Holidays;
using DailyOperations.Domain.Interfaces.Repositories.Holidays;
using DailyOperations.Persistence.Repositories.Members;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories.Holidays
{
	public class SoldierHolidayRepository : GenericRepository<SoldierHoliday>, ISoldierHolidayRepository
	{
		public SoldierHolidayRepository(DbContext context) : base(context)
		{
		}
	}
}
