using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.Interfaces.Repositories.Operations;
using DailyOperations.Persistence.Repositories.Members;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories.Operations
{
    public class OperationOfficerRepository : GenericRepository<OperationOfficer>, IOperationOfficerRepository
    {
        public OperationOfficerRepository(DbContext context) : base(context)
        {
        }
    }
}
