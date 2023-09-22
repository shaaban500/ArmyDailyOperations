using System.Linq.Expressions;
using DailyOperations.Domain.Entities;
using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services;
using DailyOperations.Domain.Interfaces.Services.Holidays;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Infrastructure.Services.Members
{
    public class soldiersService : IsoldiersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHolidayServices _holidayServices;
        public soldiersService(IUnitOfWork unitOfWork, IHolidayServices holidayServices)
        {
            _unitOfWork = unitOfWork;
            _holidayServices = holidayServices;
        }

        public async Task AddOrUpdate(Soldier model, string? certificateName, int? extraDuration, List<bool>? hasSkills)
        {
            if (model.Id == 0)
            {

                // skills
                if (hasSkills is not null && hasSkills.Count > 0)
                {
                    model.Skills = new List<Skill>();

                    for (int i = 0; i < hasSkills.Count; i++)
                    {
                        if (hasSkills[i] == true)
                        {
                            var skill = await _unitOfWork.Skills.GetByIdAsync(i + 1);
                            model.Skills.Add(skill);
                        }
                    }
                }

                var addedSoldier = await _unitOfWork.Soldiers.AddAsync(model);

                // education certificates
                if (model.EducationTypeId != 4 && certificateName != null && addedSoldier != null)
                {
                    var educationCertificate = new EducationCertificate
                    {
                        SoldierId = addedSoldier.Id,
                        CertificateName = certificateName,
                    };

                    var addedCertificate = await _unitOfWork.EducationCertificates.AddAsync(educationCertificate);
                }

                // extraDuration
                if (extraDuration is not null && extraDuration > 0 && addedSoldier != null)
                {
                    var soldierExtraDuration = new SoldiersExtraDuration
                    {
                        SoldierId = addedSoldier.Id,
                        ExtraDuration = Convert.ToInt32(extraDuration)
                    };

                    var addedExtraDuration = await _unitOfWork.SoldiersExtraDurations.AddAsync(soldierExtraDuration);
                }

            }
            else
            {
                var updatedSoldier = await _unitOfWork.Soldiers.UpdateAsync(model);
            }
        }

        public Task AddOrUpdate(Soldier model)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(long id)
        {
            var soldier = await _unitOfWork.Soldiers.GetByIdAsync(x => x.Id == id);

            if (soldier is not null)
            {
                _unitOfWork.Soldiers.Remove(soldier);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<List<Soldier>> GetAll(long operationId)
        {
            var includes = new Expression<Func<Soldier, object>>[]
                                            {
                                                p => p.PowerType,
                                                p => p.Department,
                                                p => p.EducationType,
                                                p => p.Skills,
                                            };

            var soldiers = await _unitOfWork.Soldiers.GetAllAsync(null, null, includes);

			var operation = await _unitOfWork.Operations.GetByIdAsync(operationId);
			
   //         if (operation != null)
			//{
			//	var operationDate = operation.Date;

			//	var operationSoldiers = await _unitOfWork.OperationSoldiers.GetAllAsync(x => x.Operation.Date == operationDate);
			//	var soldiersInOperations = await operationSoldiers.Select(x => x.SoldierId).ToListAsync();

			//	var soldiersAsDrivers = await _unitOfWork.OperationVehicles.GetAllAsync(x => x.DriverType == 3 && x.Operation.Date == operationDate);
			//	var soldiersInVehiclesIDs = await soldiersAsDrivers.Select(x => x.DriverId).ToListAsync();

			//	var availableSoldiers = soldiers.ToList().Where(x => !soldiersInOperations.Contains(x.Id) && !soldiersInVehiclesIDs.Contains(x.Id)).ToList();


   //             var allSoldiers = new List<Soldier>();

   //             foreach (var soldier in availableSoldiers)
   //             {
   //                 if (await _holidayServices.IsSoldierInHoliday(soldier.Id, operationDate) != true)
   //                 {
   //                     allSoldiers.Add(soldier);
   //                 }
   //             }

   //             return allSoldiers;

			//}

            return soldiers.ToList();
		}

		public async Task<List<Soldier>> GetAll()
		{
			var includes = new Expression<Func<Soldier, object>>[]
										   {
												p => p.PowerType,
												p => p.Department,
												p => p.EducationType,
												p => p.Skills,
										   };

			var soldiers = await _unitOfWork.Soldiers.GetAllAsync(null, x=>x.OrderBy(x => x.Name), includes);

			return soldiers.ToList();
		}
	}
}
