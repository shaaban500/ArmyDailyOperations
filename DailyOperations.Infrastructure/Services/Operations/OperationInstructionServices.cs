using DailyOperations.Domain.Entities;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Operations;

namespace DailyOperations.Infrastructure.Services.Operations
{
    public class OperationInstructionServices : IOperationInstructionServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public OperationInstructionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddOrUpdate(OperationInstruction model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OperationInstruction>> GetAll()
        {
            var operationInstructions = await _unitOfWork.OperationInstructions.GetAllAsync();
            return operationInstructions.ToList();
        }
    }
}
