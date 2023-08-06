using DailyOperations.Domain.Entities.Holidays;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Holidays;

namespace DailyOperations.Infrastructure.Services.Holidays
{
    public class SeedOfficerHolidaysData : ISeedOfficerHolidaysData
    {
        private readonly IUnitOfWork _unitOfWork;
        public SeedOfficerHolidaysData(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SeedOfficerHolidays()
        {
            var officers = await _unitOfWork.PoliceOfficers.GetAllAsync();
            var officerIds = officers.Select(s => s.Id).ToList();

            var officerHolidays = await _unitOfWork.OfficerHolidays.GetAllAsync();
            var existingOfficerIds = officerHolidays.Select(sh => sh.PoliceOfficerId).ToList();

            var newOfficerIds = officerIds.Except(existingOfficerIds);

            foreach (var officerId in newOfficerIds)
            {
                var officerHoliday = new OfficerHoliday
                {
                    PoliceOfficerId = officerId,
                };

                await _unitOfWork.OfficerHolidays.AddAsync(officerHoliday);
            }

        }
    }
}
