using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.ViewModels.PoliceOfficers;

namespace DailyOperations.Domain.Interfaces.Services.Members
{
    public interface IPoliceOfficersService : ICRUDServices<PoliceOfficer>
    {
        Task<List<PoliceOfficer>> GetAll(long operationId);
        Task AddOrUpdate(GetAllPoliceOfficersViewModel model);
    }
}
