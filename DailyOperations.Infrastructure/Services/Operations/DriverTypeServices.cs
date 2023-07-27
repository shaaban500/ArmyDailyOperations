using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Operations;

namespace DailyOperations.Infrastructure.Services.Operations
{
    public class DriverTypeServices : IDriverTypeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public DriverTypeServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddOrUpdate(DriverType model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DriverType>> GetAll()
        {
            var driverTypes = await _unitOfWork.DriverTypes.GetAllAsync();
            return driverTypes.ToList();
        }
    }
}
