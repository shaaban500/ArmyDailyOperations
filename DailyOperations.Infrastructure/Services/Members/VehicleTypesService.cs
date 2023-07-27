using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services;

namespace DailyOperations.Infrastructure.Services.Members
{
    public class VehicleTypesService : IVehicleTypesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public VehicleTypesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddOrUpdate(VehicleType model)
        {
            if (model.Id == 0)
            {
                var vehicleTypes = await _unitOfWork.VehicleTypes.GetByIdAsync(x => x.Type == model.Type);
                if (vehicleTypes is null)
                {
                    var addedVehicleType = await _unitOfWork.VehicleTypes.AddAsync(model);
                }
            }
            else
            {
                var updatedVehicleType = await _unitOfWork.VehicleTypes.UpdateAsync(model);
            }
        }

        public async Task Delete(long id)
        {
            var vehicleType = await _unitOfWork.VehicleTypes.GetByIdAsync(id);

            if (vehicleType is not null)
            {
                _unitOfWork.VehicleTypes.Remove(vehicleType);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<List<VehicleType>> GetAll()
        {
            var vehicleTypes = await _unitOfWork.VehicleTypes.GetAllAsync();
            return vehicleTypes.ToList();
        }
    }
}
