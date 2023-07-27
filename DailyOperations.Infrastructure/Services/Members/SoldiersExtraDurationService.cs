using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services;

namespace DailyOperations.Infrastructure.Services.Members
{
    public class SoldiersExtraDurationService : ISoldiersExtraDurationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SoldiersExtraDurationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddOrUpdate(SoldiersExtraDuration model)
        {
            if (model.Id == 0)
            {
                var addedExtraDuration = await _unitOfWork.SoldiersExtraDurations.AddAsync(model);
            }
            else
            {
                var updatedExtraDuration = await _unitOfWork.SoldiersExtraDurations.UpdateAsync(model);
            }
        }

        public async Task Delete(long id)
        {
            var soldiersExtraDuration = await _unitOfWork.SoldiersExtraDurations.GetByIdAsync(x => x.Id == id);

            if (soldiersExtraDuration is not null)
            {
                _unitOfWork.SoldiersExtraDurations.Remove(soldiersExtraDuration);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<List<SoldiersExtraDuration>> GetAll()
        {
            var soldiersExtraDurations = await _unitOfWork.SoldiersExtraDurations.GetAllAsync();
            return soldiersExtraDurations.ToList();
        }
    }
}
