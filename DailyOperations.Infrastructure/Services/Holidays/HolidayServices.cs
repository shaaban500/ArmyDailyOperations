using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Holidays;

namespace DailyOperations.Infrastructure.Services.Holidays
{
    public class HolidayServices : IHolidayServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public HolidayServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> IsSoldierInHoliday(long id, DateTime operationDate)
        {
            var soldierHoliday = await _unitOfWork.SoldierHolidays.GetByIdAsync(x =>
                                        x.IsFinished != true &&
                                        x.HolidayStartDate <= operationDate &&
                                        x.HolidayEndDate >= operationDate &&
                                        x.SoldierId == id);

            return soldierHoliday != null;
        }

        public async Task<bool> IsOfficerInHoliday(long id, DateTime operationDate)
        {
            var officerHoliday = await _unitOfWork.OfficerHolidays.GetByIdAsync(x =>
                                        x.IsFinished != true &&
                                        x.HolidayStartDate <= operationDate &&
                                        x.HolidayEndDate >= operationDate &&
                                        x.PoliceOfficerId == id);

            return officerHoliday != null;
        }

        public async Task<bool> IsAssistantInHoliday(long id, DateTime operationDate)
        {
            var assistantHoliday = await _unitOfWork.AssistantHolidays.GetByIdAsync(x =>
                                        x.IsFinished != true &&
                                        x.HolidayStartDate <= operationDate &&
                                        x.HolidayEndDate >= operationDate &&
                                        x.PoliceAssistantId == id);

            return assistantHoliday != null;
        }

    }
}
