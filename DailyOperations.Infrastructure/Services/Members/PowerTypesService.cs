using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Members;

namespace DailyOperations.Infrastructure.Services
{
    public class PowerTypesService : IPowerTypesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PowerTypesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddOrUpdate(PowerType model)
        {
            if (model.Id == 0)
            {
                var powerType = await _unitOfWork.PowerTypes.AddAsync(model);
            }
            else
            {
                var powerType = await _unitOfWork.PowerTypes.UpdateAsync(model);
            }
        }

        public async Task Delete(long id)
        {
            var powerType = await _unitOfWork.PowerTypes.GetByIdAsync(x => x.Id == id);

            if (powerType is not null)
            {
                _unitOfWork.PowerTypes.Remove(powerType);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<List<PowerType>> GetAll()
        {
            var powerTypes = await _unitOfWork.PowerTypes.GetAllAsync();
            return powerTypes.ToList();
        }
    }
}
