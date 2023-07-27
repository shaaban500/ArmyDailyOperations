using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces.Repositories.Members;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories.Members
{
    public class SkillsRepository : GenericRepository<Skill>, ISkillsRepository
    {
        public SkillsRepository(DbContext context) : base(context)
        {
        }
    }
}
