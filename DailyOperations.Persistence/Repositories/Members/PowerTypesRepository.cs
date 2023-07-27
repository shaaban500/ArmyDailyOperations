using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories.Members
{
    public class PowerTypesRepository : GenericRepository<PowerType>, IPowerTypesRepository
    {
        public PowerTypesRepository(DbContext context) : base(context)
        {
        }
    }
}
