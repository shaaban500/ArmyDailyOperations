using System.Linq.Expressions;
using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Holidays;
using DailyOperations.Domain.Interfaces.Services.Members;
using DailyOperations.Domain.ViewModels.PoliceOfficers;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Infrastructure.Services.Members
{
    public class PoliceOfficersService : IPoliceOfficersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHolidayServices _holidayServices;
        public PoliceOfficersService(IUnitOfWork unitOfWork, IHolidayServices holidayServices)
        {
            _unitOfWork = unitOfWork;
            _holidayServices = holidayServices;
        }

        public async Task<List<PoliceOfficer>> GetAll(long operaionId)
        {
            var includes = new Expression<Func<PoliceOfficer, object>>[]
                                            {
                                                p => p.PowerType,
                                                p => p.InnerDepartment,
                                                p => p.GeneralDepartment,
                                                p => p.OfficerMilitaryDegree,
                                            };
            Func<IQueryable<PoliceOfficer>, IOrderedQueryable<PoliceOfficer>> orderBy = q => q.OrderByDescending(md => md.OfficerMilitaryDegree.DisplayOrder).ThenBy(x => x.Name);
            var policeOfficers = await _unitOfWork.PoliceOfficers.GetAllAsync(null, orderBy, includes);

            var operation = await _unitOfWork.Operations.GetByIdAsync(operaionId);

            if (operation != null)
            {
                var operationDate = operation.Date;

                var operationOfficers = await _unitOfWork.OperationOfficers.GetAllAsync(x => x.Operation.Date == operationDate);
                var officersInOperations = await operationOfficers.Select(x => x.PoliceOfficerId).ToListAsync();

                var officersAsDrivers = await _unitOfWork.OperationVehicles.GetAllAsync(x => x.DriverType == 1 && x.Operation.Date == operationDate);
                var officersInVehiclesIDs = await officersAsDrivers.Select(x => x.DriverId).ToListAsync();

                var availableOfficers = policeOfficers.Where(x => !officersInOperations.Contains(x.Id) && !officersInVehiclesIDs.Contains(x.Id)).ToList();

                var allOfficers = new List<PoliceOfficer>();

                foreach (var officer in availableOfficers)
                {
                    if (await _holidayServices.IsOfficerInHoliday(officer.Id, operationDate) != true)
                    {
                        allOfficers.Add(officer);
                    }
                }

                return allOfficers;
            }

            return policeOfficers.ToList();
        }


        public async Task<List<PoliceOfficerViewModel>> GetAll(long operationId, DateTime dateFrom, DateTime dateTo)
        {
            var officers = await GetAll(operationId);

            var officersViewModel = officers.Select(x => new PoliceOfficerViewModel
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Phone = x.Phone,
                                        IsArmed = x.IsArmed,
                                        PowerType = x.PowerType,
                                        IsInadministrativeWork = x.IsInadministrativeWork,
                                        PoliceOfficerAlternative = x.PoliceOfficerAlternative,
                                        OfficerMilitaryDegree = x.OfficerMilitaryDegree,
                                        GeneralDepartment = x.GeneralDepartment,
                                        InnerDepartment = x.InnerDepartment,
                                        InnerDepartmentId = x.InnerDepartmentId,
                                        GeneralDepartmentId = x.GeneralDepartmentId,
                                        OfficerMilitaryDegreeId = x.OfficerMilitaryDegreeId,
                                        PoliceOfficerAlternativeId = x.PoliceOfficerAlternativeId,
                                        PowerTypeId = x.PowerTypeId,
                                        Count = _unitOfWork.OperationOfficers.GetCount(x => 
                                                                                        x.IsDeleted != true &&
                                                                                        x.Operation.Date >= dateFrom && 
                                                                                        x.Operation.Date <= dateTo
                                                                                        ),
                                    }).ToList();

            return officersViewModel;
		}

		public async Task AddOrUpdate(GetAllPoliceOfficersViewModel model)
        {
            if (model.PoliceOfficer.Id == 0)
            {
                var policeOfficer = await _unitOfWork.PoliceOfficers.AddAsync(model.PoliceOfficer);
            }
            else
            {
                var policeOfficer = await _unitOfWork.PoliceOfficers.UpdateAsync(model.PoliceOfficer);
            }
        }

        public async Task Delete(long id)
        {
            var policeOfficer = await _unitOfWork.PoliceOfficers.GetByIdAsync(x => x.Id == id);

            if (policeOfficer != null)
            {
                _unitOfWork.PoliceOfficers.Remove(policeOfficer);
                await _unitOfWork.SaveAsync();
            }
        }

		public async Task<List<PoliceOfficer>> GetAll()
		{
			var includes = new Expression<Func<PoliceOfficer, object>>[]
											{
												p => p.PowerType,
												p => p.InnerDepartment,
                                                p => p.GeneralDepartment,
												p => p.OfficerMilitaryDegree,
											};
			Func<IQueryable<PoliceOfficer>, IOrderedQueryable<PoliceOfficer>> orderBy = q => q.OrderByDescending(md => md.OfficerMilitaryDegree.DisplayOrder).ThenBy(x => x.Name);
			var policeOfficers = await _unitOfWork.PoliceOfficers.GetAllAsync(null, orderBy, includes);

			return policeOfficers.ToList();
		}

        public Task AddOrUpdate(PoliceOfficer model)
        {
            throw new NotImplementedException();
        }
    }
}
