using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services;
using DailyOperations.Domain.Interfaces.Services.Members;
using DailyOperations.Domain.Interfaces.Services.Operations;
using DailyOperations.Infrastructure.Services;
using DailyOperations.Infrastructure.Services.Members;
using DailyOperations.Infrastructure.Services.Operations;
using DailyOperations.Persistence;
using DailyOperations.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IPoliceOfficersService, PoliceOfficersService>();
builder.Services.AddScoped<IOfficersMilitaryDegreesService, OfficersMilitaryDegreesService>();


builder.Services.AddScoped<IpoliceAssistantsService, policeAssistantsService>();
builder.Services.AddScoped<IAssistantsMilitaryDegreesService, AssistantsMilitaryDegreesService>();

builder.Services.AddScoped<IsoldiersService, soldiersService>();
builder.Services.AddScoped<ISkillsService, SkillsService>();
builder.Services.AddScoped<IEducationTypesService, EducationTypesService>();

builder.Services.AddScoped<IVehiclesService, VehiclesService>();
builder.Services.AddScoped<IVehicleMarksService, VehicleMarksService>();
builder.Services.AddScoped<IVehicleTypesService, VehicleTypesService>();

builder.Services.AddScoped<IPowerTypesService, PowerTypesService>();
builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();



builder.Services.AddScoped<IDailyOperationServices, DailyOperationServices>();
builder.Services.AddScoped<IDriverTypeServices, DriverTypeServices>();
builder.Services.AddScoped<IGeneralDepartmentServices, GeneralDepartmentServices>();
builder.Services.AddScoped<IInnerDepartmentServices, InnerDepartmentServices>();
builder.Services.AddScoped<IOperatinSoldierServices, OperatinSoldierServices>();
builder.Services.AddScoped<IOperationDescriptionServices, OperationDescriptionServices>();
builder.Services.AddScoped<IOperationInstructionServices, OperationInstructionServices>();
builder.Services.AddScoped<IOperationOfficerServices, OperationOfficerServices>();
builder.Services.AddScoped<IOperationPoliceAssistantServices, OperationPoliceAssistantServices>();
builder.Services.AddScoped<IOperationServices, OperationServices>();
builder.Services.AddScoped<IOperationTypeServices, OperationTypeServices>();
builder.Services.AddScoped<IOperationVehicleServices, OperationVehicleServices>();
builder.Services.AddScoped<ISectorPlaceServices, SectorPlaceServices>();
builder.Services.AddScoped<ISectorServices, SectorServices>();
builder.Services.AddScoped<IShiftTypeServices, ShiftTypeServices>();









var app = builder.Build();

app.UseExceptionHandler("/Home/Error");
app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
