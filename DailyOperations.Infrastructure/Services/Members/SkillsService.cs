using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services;

namespace DailyOperations.Infrastructure.Services.Members
{
    public class SkillsService : ISkillsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SkillsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddOrUpdate(Skill model)
        {
            if (model.Id == 0)
            {
                var skill = await _unitOfWork.Skills.GetByIdAsync(x => x.Name == model.Name);

                if (skill is null)
                {
                    var addedskill = await _unitOfWork.Skills.AddAsync(model);
                }
            }
            else
            {
                var updatedSkill = await _unitOfWork.Skills.UpdateAsync(model);
            }
        }

        public async Task Delete(long id)
        {
            var skill = await _unitOfWork.Skills.GetByIdAsync(x => x.Id == id);

            if (skill is not null)
            {
                _unitOfWork.Skills.Remove(skill);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<List<Skill>> GetAll()
        {
            var skills = await _unitOfWork.Skills.GetAllAsync();
            return skills.ToList();
        }
    }
}
