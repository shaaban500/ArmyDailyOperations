using DailyOperations.Domain.Entities.Holidays;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Holidays;

namespace DailyOperations.Infrastructure.Services.Holidays
{
    public class SeedAssistantHolidaysData : ISeedAssistantHolidaysData
    {
        private readonly IUnitOfWork _unitOfWork;
        public SeedAssistantHolidaysData(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SeedAssistantHolidays()
        {
            var assistant = await _unitOfWork.PoliceAssistants.GetAllAsync();
            var assistantIds = assistant.Select(s => s.Id).ToList();

            var assistantHolidays = await _unitOfWork.AssistantHolidays.GetAllAsync();
            var existingAssistantIds = assistantHolidays.Select(sh => sh.PoliceAssistantId).ToList();

            var newAssistantIds = assistantIds.Except(existingAssistantIds);

            foreach (var assistantId in newAssistantIds)
            {
                var assistantHoliday = new AssistantHoliday
                {
                    PoliceAssistantId = assistantId,
                };

                await _unitOfWork.AssistantHolidays.AddAsync(assistantHoliday);
            }

        }
    }
}
