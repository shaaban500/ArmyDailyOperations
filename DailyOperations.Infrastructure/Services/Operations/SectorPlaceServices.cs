using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Operations;

namespace DailyOperations.Infrastructure.Services.Operations
{
    public class SectorPlaceServices : ISectorPlaceServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public SectorPlaceServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddOrUpdate(SectorPlace model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SectorPlace>> GetAll()
        {
            var sectorPlaces = await _unitOfWork.SectorPlaces.GetAllAsync();
            return sectorPlaces.ToList();
        }
    }
}
