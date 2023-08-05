using DailyOperations.Domain.Entities.Holidays;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Holidays;

namespace DailyOperations.Infrastructure.Services.Holidays
{
    public class SeedSoldierHolidaysData : ISeedSoldierHolidaysData
    {
        private readonly IUnitOfWork _unitOfWork;
        public SeedSoldierHolidaysData(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SeedSoldierHolidays()
        {
            var soldiers =  await _unitOfWork.Soldiers.GetAllAsync();
            var soldierIds = soldiers.Select(s => s.Id).ToList();

            var soldierHolidays = await _unitOfWork.SoldierHolidays.GetAllAsync();
            var existingSoldierIds = soldierHolidays.Select(sh => sh.SoldierId).ToList();

            var newSoldierIds = soldierIds.Except(existingSoldierIds);

            foreach (var soldierId in newSoldierIds)
            {
                var soldierHoliday = new SoldierHoliday
                {
                    SoldierId = soldierId,
                };

                await _unitOfWork.SoldierHolidays.AddAsync(soldierHoliday);
            }

        }
    }
}
