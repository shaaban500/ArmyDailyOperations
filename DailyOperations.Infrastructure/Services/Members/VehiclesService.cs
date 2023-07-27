using System.Linq.Expressions;
using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Infrastructure.Services.Members
{
    public class VehiclesService : IVehiclesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public VehiclesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddOrUpdate(Vehicle model)
        {
            if (model.Id == 0)
            {
                var vehicle = await _unitOfWork.Vehicles.GetByIdAsync(x => x.VehicleTypeId == model.VehicleTypeId &&
                                x.VehicleLetters == model.VehicleLetters && x.VehicleNumbers == model.VehicleNumbers);

                if (vehicle is null)
                {
                    var addedVehicle = await _unitOfWork.Vehicles.AddAsync(model);
                }
            }
            else
            {
                var updatedVehicle = await _unitOfWork.Vehicles.UpdateAsync(model);
            }
        }

        public async Task Delete(long id)
        {
            var vehicle = await _unitOfWork.Vehicles.GetByIdAsync(id);

            if (vehicle is not null)
            {
                _unitOfWork.Vehicles.Remove(vehicle);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<List<Vehicle>> GetAll(long operationId)
        {
            var includes = new Expression<Func<Vehicle, object>>[]
            {
                p => p.VehicleMark,
                p => p.VehicleType,
            };

            var vehicles = await _unitOfWork.Vehicles.GetAllAsync(null, null, includes);

			var operation = await _unitOfWork.Operations.GetByIdAsync(operationId);
			
            if (operation != null)
			{
				var operationDate = operation.Date;

				var operationVehicles = await _unitOfWork.OperationVehicles.GetAllAsync(x => x.Operation.Date == operationDate);
				var vehiclesInOperations = await operationVehicles.Select(x => x.VehicleId).ToListAsync();

				var availableVehicles = vehicles.Where(x => !vehiclesInOperations.Contains(x.Id)).ToList();

				return availableVehicles;
			}

            return vehicles.ToList();
		}

		public async Task<List<Vehicle>> GetAll()
		{
            var vehicles = await _unitOfWork.Vehicles.GetAllAsync(null, null, x => x.VehicleType);

            return vehicles.ToList();
		}
	}
}
