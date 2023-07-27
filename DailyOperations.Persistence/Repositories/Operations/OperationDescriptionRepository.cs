using DailyOperations.Domain.Entities;
using DailyOperations.Domain.Interfaces.Repositories.Operations;
using DailyOperations.Persistence.Repositories.Members;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories.Operations
{
    public class OperationDescriptionRepository : GenericRepository<OperationDescription>, IOperationDescriptionRepository
    {
        public OperationDescriptionRepository(DbContext context) : base(context)
        {
        }
    }
}
