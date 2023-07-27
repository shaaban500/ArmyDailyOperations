using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories.Members
{
    public class VehicleTypesRepository : GenericRepository<VehicleType>, IVehicleTypesRepository
    {
        public VehicleTypesRepository(DbContext context) : base(context)
        {
        }
    }
}
