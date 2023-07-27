using System.Linq.Expressions;

namespace DailyOperations.Domain.Interfaces.Services
{
    public interface ICRUDServices<T>
    {
        Task<List<T>> GetAll();
        Task AddOrUpdate(T model);
        Task Delete(long id);
    }
}
