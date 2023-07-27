using DailyOperations.Domain.Entities.Members;

namespace DailyOperations.Domain.Interfaces.Services
{
    public interface IVehiclesService : ICRUDServices<Vehicle>
    {
        Task<List<Vehicle>> GetAll(long operationId);
    }
}
