using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories.Members
{
    public class PoliceOfficersRepository : GenericRepository<PoliceOfficer>, IPoliceOfficersRepository
    {
        public PoliceOfficersRepository(DbContext context) : base(context)
        {
        }
    }
}
