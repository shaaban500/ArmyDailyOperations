using DailyOperations.Domain.Entities;

namespace DailyOperations.Domain.Interfaces.Services
{
    public interface IsoldiersService : ICRUDServices<Soldier>
    {
        Task AddOrUpdate(Soldier model, string? certificateName, int? extraDuration, List<bool>? hasSkills);
        Task<List<Soldier>> GetAll(long operationId);
        
    }
}
