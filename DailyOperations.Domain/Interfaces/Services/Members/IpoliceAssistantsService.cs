using DailyOperations.Domain.Entities.Members;

namespace DailyOperations.Domain.Interfaces.Services
{
    public interface IpoliceAssistantsService : ICRUDServices<PoliceAssistant>
    {
        Task<List<PoliceAssistant>> GetAll(long operationId);
    }
}
