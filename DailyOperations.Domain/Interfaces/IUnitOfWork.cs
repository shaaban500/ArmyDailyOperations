using DailyOperations.Domain.Interfaces.Repositories;
using DailyOperations.Domain.Interfaces.Repositories.Members;
using DailyOperations.Domain.Interfaces.Repositories.Operations;

namespace DailyOperations.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Members

        ISoldierRepository Soldiers { get; }
        ISkillsRepository Skills { get; }
        IEducationTypesRepository EducationTypes { get; }
        IPoliceOfficersRepository PoliceOfficers { get; }
        IPoliceAssistantsRepository PoliceAssistants { get; }
        IOfficerMilitaryDegreesRepository OfficerMilitaryDegrees { get; }
        IAssistantMilitaryDegreesRepository AssistantMilitaryDegrees { get; }
        IDepartmentRepository Departments { get; }
        IPowerTypesRepository PowerTypes { get; }
        IVehiclesRepository Vehicles { get; }
        IVehicleMarksRepository VehicleMarks { get; }
        IVehicleTypesRepository VehicleTypes { get; }
        ISoldiersExtraDurationRepository SoldiersExtraDurations { get; }
        IEducationCertificateRepository EducationCertificates { get; }

        #endregion

        #region Operations

        IDailyOperationRepository DailyOperations { get; }
        IDriverTypeRepository DriverTypes { get; }
        IGeneralDepartmentRepository GeneralDepartments { get; }
        IInnerDepartmentRepository InnerDepartments { get; }
        IOperatinSoldierRepository OperationSoldiers { get; }
        IOperationDescriptionRepository OperationDescriptions { get; }
        IOperationInstructionRepository OperationInstructions { get; }
        IOperationOfficerRepository OperationOfficers { get; }
        IOperationPoliceAssistantRepository OperationPoliceAssistants { get; }
        IOperationRepository Operations { get; }
        IOperationTypeRepository OperationTypes { get; }
        IOperationVehicleRepository OperationVehicles { get; }
        ISectorPlaceRepository SectorPlaces { get; }
        ISectorRepository Sectors { get; }
        IShiftTypeRepository ShiftTypes { get; }

        #endregion

        void Save();
        Task<int> SaveAsync();
    }
}
