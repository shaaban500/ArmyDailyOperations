using DailyOperations.Domain.Entities;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Operations;

namespace DailyOperations.Infrastructure.Services.Operations
{
    public class OperationDescriptionServices : IOperationDescriptionServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public OperationDescriptionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddOrUpdate(OperationDescription model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OperationDescription>> GetAll()
        {
            var operationDescriptions = await _unitOfWork.OperationDescriptions.GetAllAsync();
            return operationDescriptions.ToList();
        }
    }
}
