using DailyOperations.Domain.Entities;
using DailyOperations.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Repositories.Members
{
    public class SoldierRepository : GenericRepository<Soldier>, ISoldierRepository
    {
        public SoldierRepository(DbContext context) : base(context)
        {
        }
    }
}
