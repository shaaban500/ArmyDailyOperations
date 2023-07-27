using System.Linq.Expressions;
using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Infrastructure.Services.Members
{
    public class policeAssistantsService : IpoliceAssistantsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public policeAssistantsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PoliceAssistant>> GetAll(long operationId)
        {
            var includes = new Expression<Func<PoliceAssistant, object>>[]
                                            {
                                                p => p.PowerType,
                                                p => p.Department,
                                                p => p.AssistantsMilitaryDegree,
                                            };
            Func<IQueryable<PoliceAssistant>, IOrderedQueryable<PoliceAssistant>> orderBy = q => q.OrderByDescending(md => md.AssistantsMilitaryDegree.DisplayOrder).ThenBy(x => x.Name);
            var policeAssistants = await _unitOfWork.PoliceAssistants.GetAllAsync(null, orderBy, includes);
			
            
            var operation = await _unitOfWork.Operations.GetByIdAsync(operationId);
            
			if (operation != null)
			{
				var operationDate = operation.Date;

				var operationAssistants = await _unitOfWork.OperationPoliceAssistants.GetAllAsync(x => x.Operation.Date == operationDate);
                var assistantsInOperations = await operationAssistants.Select(x => x.PoliceAssistantId).ToListAsync();

				var assistantsAsDrivers = await _unitOfWork.OperationVehicles.GetAllAsync(x => x.DriverType == 2 && x.Operation.Date == operationDate);
				var assistantsInVehiclesIDs = await assistantsAsDrivers.Select(x => x.DriverId).ToListAsync();

				var availableAssistants = await policeAssistants.Where(x => !assistantsInOperations.Contains(x.Id) && !assistantsInVehiclesIDs.Contains(x.Id)).ToListAsync();

				return availableAssistants;
			}

            return policeAssistants.ToList();

		}

        public async Task AddOrUpdate(PoliceAssistant model)
        {
            if (model.Id == 0)
            {
                var policeAssistant = await _unitOfWork.PoliceAssistants.AddAsync(model);
            }
            else
            {
                var policeAssistant = await _unitOfWork.PoliceAssistants.UpdateAsync(model);
            }
        }

        public async Task Delete(long id)
        {
            var policeAssistant = await _unitOfWork.PoliceAssistants.GetByIdAsync(x => x.Id == id);

            if (policeAssistant != null)
            {
                _unitOfWork.PoliceAssistants.Remove(policeAssistant);
                await _unitOfWork.SaveAsync();
            }
        }

		public async Task<List<PoliceAssistant>> GetAll()
		{
			var includes = new Expression<Func<PoliceAssistant, object>>[]
											{
												p => p.PowerType,
												p => p.Department,
												p => p.AssistantsMilitaryDegree,
											};
			Func<IQueryable<PoliceAssistant>, IOrderedQueryable<PoliceAssistant>> orderBy = q => q.OrderByDescending(md => md.AssistantsMilitaryDegree.DisplayOrder).ThenBy(x => x.Name);
			
            var policeAssistants = await _unitOfWork.PoliceAssistants.GetAllAsync(null, orderBy, includes);

            return policeAssistants.ToList();
		}
	}
}
