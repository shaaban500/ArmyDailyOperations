using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Operations;

namespace DailyOperations.Infrastructure.Services.Operations
{
    public class SectorServices : ISectorServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public SectorServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddOrUpdate(Sector model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Sector>> GetAll()
        {
            var sectors = await _unitOfWork.Sectors.GetAllAsync();
            return sectors.ToList();
        }
    }
}
