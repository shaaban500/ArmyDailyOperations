using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Operations;

namespace DailyOperations.Infrastructure.Services.Operations
{
    public class InnerDepartmentServices : IInnerDepartmentServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public InnerDepartmentServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddOrUpdate(InnerDepartment model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<InnerDepartment>> GetAll()
        {
            var innerDepartments = await _unitOfWork.InnerDepartments.GetAllAsync();
            return innerDepartments.ToList();
        }
    }
}
