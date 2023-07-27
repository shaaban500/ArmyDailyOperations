using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Members;

namespace DailyOperations.Infrastructure.Services.Members
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task AddOrUpdate(Department model)
        {
            if (model.Id == 0)
            {
                var department = await _unitOfWork.Departments.AddAsync(model);
            }
            else
            {
                var department = await _unitOfWork.Departments.UpdateAsync(model);
            }
        }

        public async Task Delete(long id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(x => x.Id == id);

            if (department is not null)
            {
                _unitOfWork.Departments.Remove(department);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<List<Department>> GetAll()
        {
            var departments = await _unitOfWork.Departments.GetAllAsync();
            return departments.ToList();
        }
    }
}
