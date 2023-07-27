using DailyOperations.Domain.Entities.Members;

namespace DailyOperations.Domain.Interfaces.Services.Members
{
    public interface IPoliceOfficersService : ICRUDServices<PoliceOfficer>
    {
        Task<List<PoliceOfficer>> GetAll(long operationId);
    }
}
