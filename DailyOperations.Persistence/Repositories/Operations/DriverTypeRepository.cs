using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.Interfaces.Repositories.Operations;
using DailyOperations.Persistence.Repositories.Members;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories.Operations
{
    public class DriverTypeRepository : GenericRepository<DriverType>, IDriverTypeRepository
    {
        public DriverTypeRepository(DbContext context) : base(context)
        {
        }
    }
}
