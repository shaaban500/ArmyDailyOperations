using DailyOperations.Domain.Entities.Holidays;
using DailyOperations.Domain.Interfaces.Repositories.Holidays;
using DailyOperations.Persistence.Repositories.Members;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories.Holidays
{
	public class AssistantHolidayRepository : GenericRepository<AssistantHoliday>, IAssistantHolidayRepository
	{
		public AssistantHolidayRepository(DbContext context) : base(context)
		{
		}
	}
}
