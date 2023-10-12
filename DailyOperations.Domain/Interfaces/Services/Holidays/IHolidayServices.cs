namespace DailyOperations.Domain.Interfaces.Services.Holidays
{
    public interface IHolidayServices
    {
        Task<bool> IsOfficerInHoliday(long id, DateTime operationDate);
        Task<bool> IsAssistantInHoliday(long id, DateTime operationDate);
        Task<bool> IsSoldierInHoliday(long id, DateTime operationDate);
        Task<int> GetHolidaysCount(long operationId);
	}
}
