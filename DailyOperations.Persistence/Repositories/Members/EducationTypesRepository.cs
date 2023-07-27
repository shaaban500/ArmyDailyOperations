using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories.Members
{
    public class EducationTypesRepository : GenericRepository<EducationType>, IEducationTypesRepository
    {
        public EducationTypesRepository(DbContext context) : base(context)
        {
        }
    }
}
