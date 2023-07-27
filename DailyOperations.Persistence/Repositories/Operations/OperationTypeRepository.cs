using DailyOperations.Domain.Entities;
using DailyOperations.Domain.Interfaces.Repositories.Operations;
using DailyOperations.Persistence.Repositories.Members;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories.Operations
{
    public class OperationTypeRepository : GenericRepository<OperationType>, IOperationTypeRepository
    {
        public OperationTypeRepository(DbContext context) : base(context)
        {
        }
    }
}
