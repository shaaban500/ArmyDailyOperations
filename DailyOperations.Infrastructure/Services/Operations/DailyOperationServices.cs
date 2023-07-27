using DailyOperations.Domain.Entities;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Operations;

namespace DailyOperations.Infrastructure.Services.Operations
{
    public class DailyOperationServices : IDailyOperationServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public DailyOperationServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddOrUpdate(DailyOperation model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DailyOperation>> GetAll()
        {
            var dailyOperations = await _unitOfWork.DailyOperations.GetAllAsync();
            return dailyOperations.ToList();
        }
    }
}
