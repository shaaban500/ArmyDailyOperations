using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces.Repositories.Members;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories.Members
{
    public class AssistantMilitaryDegreesRepository : GenericRepository<AssistantsMilitaryDegree>, IAssistantMilitaryDegreesRepository
    {
        public AssistantMilitaryDegreesRepository(DbContext context) : base(context)
        {
        }
    }
}
