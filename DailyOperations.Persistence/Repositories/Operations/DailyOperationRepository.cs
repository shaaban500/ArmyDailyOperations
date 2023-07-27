using DailyOperations.Domain.Entities;
using DailyOperations.Domain.Interfaces.Repositories.Operations;
using DailyOperations.Persistence.Repositories.Members;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories.Operations
{
    public class DailyOperationRepository : GenericRepository<DailyOperation>, IDailyOperationRepository
    {
        public DailyOperationRepository(DbContext context) : base(context)
        {
        }
    }
}
