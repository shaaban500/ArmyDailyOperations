using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories.Members
{
    public class PoliceAssistantsRepository : GenericRepository<PoliceAssistant>, IPoliceAssistantsRepository
    {
        public PoliceAssistantsRepository(DbContext context) : base(context)
        {
        }
    }
}
