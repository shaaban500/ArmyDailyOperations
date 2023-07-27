using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.Interfaces.Repositories.Operations;
using DailyOperations.Persistence.Repositories.Members;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories.Operations
{
    public class ShiftTypeRepository : GenericRepository<ShiftType>, IShiftTypeRepository
    {
        public ShiftTypeRepository(DbContext context) : base(context)
        {
        }
    }
}
