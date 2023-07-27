using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Members;

namespace DailyOperations.Infrastructure.Services
{
    public class EducationTypesService : IEducationTypesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EducationTypesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddOrUpdate(EducationType model)
        {
            if (model.Id == 0)
            {
                var educationType = await _unitOfWork.EducationTypes.AddAsync(model);
            }
            else
            {
                var educationType = await _unitOfWork.EducationTypes.UpdateAsync(model);
            }
        }

        public async Task Delete(long id)
        {
            var educationType = await _unitOfWork.EducationTypes.GetByIdAsync(x => x.Id == id);

            if (educationType is not null)
            {
                _unitOfWork.EducationTypes.Remove(educationType);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<List<EducationType>> GetAll()
        {
            var educationTypes = await _unitOfWork.EducationTypes.GetAllAsync();
            return educationTypes.ToList();
        }
    }
}
