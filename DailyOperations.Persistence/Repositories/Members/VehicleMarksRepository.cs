using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories.Members
{
    public class VehicleMarksRepository : GenericRepository<VehicleMark>, IVehicleMarksRepository
    {
        public VehicleMarksRepository(DbContext context) : base(context)
        {
        }
    }
}
