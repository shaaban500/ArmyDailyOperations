using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services;

namespace DailyOperations.Infrastructure.Services.Members
{
    public class VehicleMarksService : IVehicleMarksService
    {
        private readonly IUnitOfWork _unitOfWork;
        public VehicleMarksService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddOrUpdate(VehicleMark model)
        {
            if (model.Id == 0)
            {
                var vehicleMark = await _unitOfWork.VehicleMarks.GetByIdAsync(x => x.Mark == model.Mark);
                if (vehicleMark is null)
                {
                    var addedVehicleMark = await _unitOfWork.VehicleMarks.AddAsync(model);
                }
            }
            else
            {
                var updatedVehicleMark = await _unitOfWork.VehicleMarks.UpdateAsync(model);
            }
        }

        public async Task Delete(long id)
        {
            var vehicleMark = await _unitOfWork.VehicleMarks.GetByIdAsync(id);

            if (vehicleMark is not null)
            {
                _unitOfWork.VehicleMarks.Remove(vehicleMark);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<List<VehicleMark>> GetAll()
        {
            var vehicleMarks = await _unitOfWork.VehicleMarks.GetAllAsync();
            return vehicleMarks.ToList();
        }
    }
}
