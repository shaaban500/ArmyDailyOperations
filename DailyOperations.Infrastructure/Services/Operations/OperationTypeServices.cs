using DailyOperations.Domain.Entities;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Operations;

namespace DailyOperations.Infrastructure.Services.Operations
{
    public class OperationTypeServices : IOperationTypeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public OperationTypeServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddOrUpdate(OperationType model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OperationType>> GetAll()
        {
            var operationTypes = await _unitOfWork.OperationTypes.GetAllAsync();
            return operationTypes.ToList();
        }
    }
}
