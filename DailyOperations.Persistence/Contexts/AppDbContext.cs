using DailyOperations.Domain.Entities;
using DailyOperations.Domain.Entities.Holidays;
using DailyOperations.Domain.Entities.Members;
using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace DailyOperations.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        //private readonly IDateTimeService _dateTime;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        #region Members

        public DbSet<PoliceOfficer> PoliceOfficers { get; set; }
        public DbSet<OfficerMilitaryDegree> OfficerMilitaryDegrees { get; set; }
        public DbSet<PoliceAssistant> PoliceAssistants { get; set; }
        public DbSet<AssistantsMilitaryDegree> AssistantMilitaryDegrees { get; set; }
        public DbSet<Soldier> Soldiers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EducationType> EducationTypes { get; set; }
        public DbSet<EducationCertificate> EducationCertificates { get; set; }
        public DbSet<SoldiersExtraDuration> SoldiersExtraDurations { get; set; }
        public DbSet<PowerType> PowerTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleMark> VehicleMarks { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

        #endregion

        #region Operations

        public DbSet<DailyOperation> DailyOperations { get; set; }
        public DbSet<GeneralDepartment> GeneralDepartments { get; set; }
        public DbSet<InnerDepartment> InnerDepartments { get; set; }
        public DbSet<OperatinSoldier> OperatinSoldiers { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationDescription> OperationDescriptions { get; set; }
        public DbSet<OperationInstruction> OperationInstructions { get; set; }
        public DbSet<OperationOfficer> OperationOfficers { get; set; }
        public DbSet<OperationPoliceAssistant> OperationPoliceAssistants { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<OperationVehicle> OperationVehicles { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<SectorPlace> SectorPlaces { get; set; }
        public DbSet<ShiftType> ShiftTypes { get; set; }

        #endregion

        #region Holidays

        public DbSet<HolidayType> HolidayTypes { get; set; }
        public DbSet<OfficerHoliday> OfficerHolidays { get; set; }
        public DbSet<AssistantHoliday> AssistantHolidays { get; set; }
        public DbSet<SoldierHoliday> SoldierHolidays { get; set; }

        #endregion

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //var userId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                }

                if (entry.State == EntityState.Added)
                {
                    //entry.Entity.CreatedAt = _dateTime.NowUtc;
                }

                if (entry.State == EntityState.Modified)
                {
                    //entry.Entity.UpdatedAt = _dateTime.NowUtc;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Seed

            builder.Entity<OfficerMilitaryDegree>().HasData(
                new OfficerMilitaryDegree
                {
                    Id = 1,
                    Degree = "ملازم",
                    DisplayOrder = 1
                }
            );

            builder.Entity<OfficerMilitaryDegree>().HasData(
                new OfficerMilitaryDegree
                {
                    Id = 2,
                    Degree = "ملازم أول",
                    DisplayOrder = 2
                }
            );

            builder.Entity<OfficerMilitaryDegree>().HasData(
                new OfficerMilitaryDegree
                {
                    Id = 3,
                    Degree = "نقيب",
                    DisplayOrder = 3
                }
            );

            builder.Entity<OfficerMilitaryDegree>().HasData(
                new OfficerMilitaryDegree
                {
                    Id = 4,
                    Degree = "رائد",
                    DisplayOrder = 4
                }
            );

            builder.Entity<OfficerMilitaryDegree>().HasData(
                new OfficerMilitaryDegree
                {
                    Id = 5,
                    Degree = "مقدم",
                    DisplayOrder = 5
                }
            );

            builder.Entity<OfficerMilitaryDegree>().HasData(
                new OfficerMilitaryDegree
                {
                    Id = 6,
                    Degree = "عقيد",
                    DisplayOrder = 6
                }
            );

            builder.Entity<OfficerMilitaryDegree>().HasData(
                new OfficerMilitaryDegree
                {
                    Id = 7,
                    Degree = "عميد",
                    DisplayOrder = 7
                }
            );

            builder.Entity<OfficerMilitaryDegree>().HasData(
                new OfficerMilitaryDegree
                {
                    Id = 8,
                    Degree = "لواء",
                    DisplayOrder = 8
                }
            );

            builder.Entity<OfficerMilitaryDegree>().HasData(
                new OfficerMilitaryDegree
                {
                    Id = 9,
                    Degree = "مساعد وزير",
                    DisplayOrder = 8
                }
            );

            builder.Entity<OfficerMilitaryDegree>().HasData(
                new OfficerMilitaryDegree
                {
                    Id = 10,
                    Degree = "مساعد أول وزير",
                    DisplayOrder = 8
                }
            );

            #endregion

        }
    }
}
