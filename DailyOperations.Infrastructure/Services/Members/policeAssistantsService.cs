using System.Linq.Expressions;
using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services;
using DailyOperations.Domain.Interfaces.Services.Holidays;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Infrastructure.Services.Members
{
    public class policeAssistantsService : IpoliceAssistantsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHolidayServices _holidayServices;
        public policeAssistantsService(IUnitOfWork unitOfWork, IHolidayServices holidayServices)
        {
            _unitOfWork = unitOfWork;
            _holidayServices = holidayServices;
        }

        public async Task<List<PoliceAssistant>> GetAll(long operationId)
        {
            var includes = new Expression<Func<PoliceAssistant, object>>[]
                                            {
                                                p => p.PowerType,
                                                p => p.InnerDepartment,
                                                p => p.GeneralDepartment,
                                                p => p.AssistantsMilitaryDegree,
                                            };
            Func<IQueryable<PoliceAssistant>, IOrderedQueryable<PoliceAssistant>> orderBy = q => q.OrderByDescending(md => md.AssistantsMilitaryDegree.DisplayOrder).ThenBy(x => x.Name);
            var policeAssistants = await _unitOfWork.PoliceAssistants.GetAllAsync(null, orderBy, includes);
			
            
            var operation = await _unitOfWork.Operations.GetByIdAsync(operationId);
            
			if (operation != null)
			{
				var operationDate = operation.Date;

				var operationAssistants = await _unitOfWork.OperationPoliceAssistants.GetAllAsync(x => x.Operation.Date == operationDate);
                var assistantsInOperations = operationAssistants.Select(x => x.PoliceAssistantId).ToList();

				var assistantsAsDrivers = await _unitOfWork.OperationVehicles.GetAllAsync(x => x.DriverType == 2 && x.Operation.Date == operationDate);
				var assistantsInVehiclesIDs = assistantsAsDrivers.Select(x => x.DriverId).ToList();

				var availableAssistants = await policeAssistants.Where(x => !assistantsInOperations.Contains(x.Id) && !assistantsInVehiclesIDs.Contains(x.Id)).ToListAsync();

                var allAssistants = new List<PoliceAssistant>();

                foreach (var assistant in availableAssistants)
                {
                    if (await _holidayServices.IsAssistantInHoliday(assistant.Id, operationDate) != true)
                    {
                        allAssistants.Add(assistant);
                    }
                }

                return allAssistants;

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
                                                p => p.InnerDepartment,
												p => p.GeneralDepartment,
												p => p.AssistantsMilitaryDegree,
											};
			Func<IQueryable<PoliceAssistant>, IOrderedQueryable<PoliceAssistant>> orderBy = q => q.OrderByDescending(md => md.AssistantsMilitaryDegree.DisplayOrder).ThenBy(x => x.Name);
			
            var policeAssistants = await _unitOfWork.PoliceAssistants.GetAllAsync(null, orderBy, includes);

            return policeAssistants.ToList();
		}
	}
}
