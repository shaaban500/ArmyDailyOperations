using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Members;

namespace DailyOperations.Infrastructure.Services.Members
{
    public class AssistantsMilitaryDegreesService : IAssistantsMilitaryDegreesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AssistantsMilitaryDegreesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddOrUpdate(AssistantsMilitaryDegree model)
        {
            if (model.Id == 0)
            {
                var militaryDegree = await _unitOfWork.AssistantMilitaryDegrees.AddAsync(model);
            }
            else
            {
                var militaryDegree = await _unitOfWork.AssistantMilitaryDegrees.UpdateAsync(model);
            }
        }


        public async Task Delete(long id)
        {
            var assistantsMilitaryDegree = await _unitOfWork.AssistantMilitaryDegrees.GetByIdAsync(x => x.Id == id);

            if (assistantsMilitaryDegree is not null)
            {
                _unitOfWork.AssistantMilitaryDegrees.Remove(assistantsMilitaryDegree);
                await _unitOfWork.SaveAsync();
            }
        }


        public async Task<List<AssistantsMilitaryDegree>> GetAll()
        {
            var militaryDegrees = await _unitOfWork.AssistantMilitaryDegrees.GetAllAsync();
            return militaryDegrees.ToList();
        }
    }
}
