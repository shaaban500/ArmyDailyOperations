using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories.Members
{
    public class SoldiersExtraDurationRepository : GenericRepository<SoldiersExtraDuration>,
        ISoldiersExtraDurationRepository
    {
        public SoldiersExtraDurationRepository(DbContext context) : base(context)
        {
        }
    }
}
