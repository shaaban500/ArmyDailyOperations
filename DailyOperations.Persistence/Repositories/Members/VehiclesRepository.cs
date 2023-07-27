using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces.Repositories;
using DailyOperations.Persistence.Repositories.Members;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories
{
    public class VehiclesRepository : GenericRepository<Vehicle>, IVehiclesRepository
    {
        public VehiclesRepository(DbContext context) : base(context)
        {
        }
    }
}
