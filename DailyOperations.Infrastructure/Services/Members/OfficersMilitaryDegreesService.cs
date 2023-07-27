using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services;

namespace DailyOperations.Infrastructure.Services.Members
{
    public class OfficersMilitaryDegreesService : IOfficersMilitaryDegreesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OfficersMilitaryDegreesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddOrUpdate(OfficerMilitaryDegree model)
        {
            if (model.Id == 0)
            {
                var officerMilitaryDegree = await _unitOfWork.OfficerMilitaryDegrees.AddAsync(model);
            }
            else
            {
                var officerMilitaryDegree = await _unitOfWork.OfficerMilitaryDegrees.UpdateAsync(model);
            }
        }

        public async Task Delete(long id)
        {
            var officerMilitaryDegree = await _unitOfWork.OfficerMilitaryDegrees.GetByIdAsync(x => x.Id == id);

            if (officerMilitaryDegree is not null)
            {
                _unitOfWork.OfficerMilitaryDegrees.Remove(officerMilitaryDegree);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<List<OfficerMilitaryDegree>> GetAll()
        {
            var militaryDegrees = await _unitOfWork.OfficerMilitaryDegrees.GetAllAsync();
            return militaryDegrees.ToList();
        }
    }
}
