using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories.Members
{
    public class OfficerMilitaryDegreesRepository : GenericRepository<OfficerMilitaryDegree>, IOfficerMilitaryDegreesRepository
    {
        public OfficerMilitaryDegreesRepository(DbContext context) : base(context)
        {
        }
    }
}
