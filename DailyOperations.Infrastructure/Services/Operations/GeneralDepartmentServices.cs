using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Operations;

namespace DailyOperations.Infrastructure.Services.Operations
{
    public class GeneralDepartmentServices : IGeneralDepartmentServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public GeneralDepartmentServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddOrUpdate(GeneralDepartment model)
        {
            var exitedDepartment = await _unitOfWork.GeneralDepartments.GetByIdAsync(x => x.Department == model.Department);
            
            if(exitedDepartment is null)
            {
                var addedGeneralDepartment = await _unitOfWork.GeneralDepartments.AddAsync(model);
            }
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GeneralDepartment>> GetAll()
        {
            var generalDepartments = await _unitOfWork.GeneralDepartments.GetAllAsync();
            return generalDepartments.ToList();
        }
    }
}
