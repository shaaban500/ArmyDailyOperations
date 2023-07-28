using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Repositories;
using DailyOperations.Domain.Interfaces.Repositories.Holidays;
using DailyOperations.Domain.Interfaces.Repositories.Members;
using DailyOperations.Domain.Interfaces.Repositories.Operations;
using DailyOperations.Persistence.Contexts;
using DailyOperations.Persistence.Repositories;
using DailyOperations.Persistence.Repositories.Holidays;
using DailyOperations.Persistence.Repositories.Members;
using DailyOperations.Persistence.Repositories.Operations;

namespace DailyOperations.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private ISoldierRepository _soldierRepository;
        private IPoliceOfficersRepository _policeOfficersRepository;
        private IPoliceAssistantsRepository _policeAssistantsRepository;
        private IOfficerMilitaryDegreesRepository _officerMilitaryDegreesRepository;
        private IAssistantMilitaryDegreesRepository _assistantMilitaryDegreesRepository;
        private IVehiclesRepository _vehiclesRepository;
        private ISkillsRepository _skillsRepository;
        private IEducationTypesRepository _educationTypesRepository;
        private IDepartmentRepository _departmentsRepository;
        private IPowerTypesRepository _powerTypesRepository;
        private IVehicleMarksRepository _vehicleMarksRepository;
        private IVehicleTypesRepository _vehicleTypesRepository;
        private ISoldiersExtraDurationRepository _soldiersExtraDurationRepository;
        private IEducationCertificateRepository _educationCertificateRepository;


        private IDailyOperationRepository _dailyOperationRepository;
        private IDriverTypeRepository _driverTypeRepository;
        private IGeneralDepartmentRepository _generalDepartmentRepository;
        private IInnerDepartmentRepository _innerDepartmentRepository;
        private IOperatinSoldierRepository _operatinSoldierRepository;
        private IOperationDescriptionRepository _operationDescriptionRepository;
        private IOperationInstructionRepository _operationInstructionRepository;
        private IOperationOfficerRepository _operationOfficerRepository;
        private IOperationPoliceAssistantRepository _operationPoliceAssistantRepository;
        private IOperationRepository _operationRepository;
        private IOperationTypeRepository _operationTypeRepository;
        private IOperationVehicleRepository _operationVehicleRepository;
        private ISectorPlaceRepository _sectorPlaceRepository;
        private ISectorRepository _sectorRepository;
        private IShiftTypeRepository _shiftTypeRepository;


        private IHolidayTypeRepository _holidayTypeRepository;
        private IOfficerHolidayRepository _officerHolidayRepository;
        private IAssistantHolidayRepository _assistantHolidayRepository;
        private ISoldierHolidayRepository _soldierHolidayRepository;

        public IHolidayTypeRepository HolidayTypes => _holidayTypeRepository ??= new HolidayTypesRepository(_context);
        public IOfficerHolidayRepository OfficerHolidays => _officerHolidayRepository ??= new OfficerHolidayRepository(_context);
        public IAssistantHolidayRepository AssistantHolidays => _assistantHolidayRepository ??= new AssistantHolidayRepository(_context);
        public ISoldierHolidayRepository SoldierHolidays => _soldierHolidayRepository ?? = new SoldierHolidayRepository(_context);

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        #region Members Repos

        public ISoldierRepository Soldiers => _soldierRepository ??= new SoldierRepository(_context);
        public IPoliceOfficersRepository PoliceOfficers => _policeOfficersRepository ??= new PoliceOfficersRepository(_context);
        public IPoliceAssistantsRepository PoliceAssistants => _policeAssistantsRepository ??= new PoliceAssistantsRepository(_context);
        public IOfficerMilitaryDegreesRepository OfficerMilitaryDegrees => _officerMilitaryDegreesRepository ??= new OfficerMilitaryDegreesRepository(_context);
        public IAssistantMilitaryDegreesRepository AssistantMilitaryDegrees => _assistantMilitaryDegreesRepository ??= new AssistantMilitaryDegreesRepository(_context);
        public IVehiclesRepository Vehicles => _vehiclesRepository ??= new VehiclesRepository(_context);
        public ISkillsRepository Skills => _skillsRepository ??= new SkillsRepository(_context);
        public IEducationTypesRepository EducationTypes => _educationTypesRepository ??= new EducationTypesRepository(_context);
        public IDepartmentRepository Departments => _departmentsRepository ??= new DepartmentRepository(_context);
        public IPowerTypesRepository PowerTypes => _powerTypesRepository ??= new PowerTypesRepository(_context);
        public IVehicleMarksRepository VehicleMarks => _vehicleMarksRepository ??= new VehicleMarksRepository(_context);
        public IVehicleTypesRepository VehicleTypes => _vehicleTypesRepository ??= new VehicleTypesRepository(_context);
        public ISoldiersExtraDurationRepository SoldiersExtraDurations => _soldiersExtraDurationRepository ??= new SoldiersExtraDurationRepository(_context);
        public IEducationCertificateRepository EducationCertificates => _educationCertificateRepository ??= new EducationCertificateRepository(_context);

        // New repositories
        public IDailyOperationRepository DailyOperations => _dailyOperationRepository ??= new DailyOperationRepository(_context);
        public IDriverTypeRepository DriverTypes => _driverTypeRepository ??= new DriverTypeRepository(_context);
        public IGeneralDepartmentRepository GeneralDepartments => _generalDepartmentRepository ??= new GeneralDepartmentRepository(_context);
        public IInnerDepartmentRepository InnerDepartments => _innerDepartmentRepository ??= new InnerDepartmentRepository(_context);
        public IOperatinSoldierRepository OperationSoldiers => _operatinSoldierRepository ??= new OperatinSoldierRepository(_context);
        public IOperationDescriptionRepository OperationDescriptions => _operationDescriptionRepository ??= new OperationDescriptionRepository(_context);
        public IOperationInstructionRepository OperationInstructions => _operationInstructionRepository ??= new OperationInstructionRepository(_context);
        public IOperationOfficerRepository OperationOfficers => _operationOfficerRepository ??= new OperationOfficerRepository(_context);
        public IOperationPoliceAssistantRepository OperationPoliceAssistants => _operationPoliceAssistantRepository ??= new OperationPoliceAssistantRepository(_context);
        public IOperationRepository Operations => _operationRepository ??= new OperationRepository(_context);
        public IOperationTypeRepository OperationTypes => _operationTypeRepository ??= new OperationTypeRepository(_context);
        public IOperationVehicleRepository OperationVehicles => _operationVehicleRepository ??= new OperationVehicleRepository(_context);
        public ISectorPlaceRepository SectorPlaces => _sectorPlaceRepository ??= new SectorPlaceRepository(_context);
        public ISectorRepository Sectors => _sectorRepository ??= new SectorRepository(_context);
        public IShiftTypeRepository ShiftTypes => _shiftTypeRepository ??= new ShiftTypeRepository(_context);

        #endregion

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}