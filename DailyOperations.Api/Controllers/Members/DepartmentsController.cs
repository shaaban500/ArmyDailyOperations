using DailyOperations.Domain.Interfaces.Services.Members;
using DailyOperations.Domain.ViewModels.PoliceAssistants;
using DailyOperations.Domain.ViewModels.PoliceOfficers;
using Microsoft.AspNetCore.Mvc;

namespace DailyOperations.Api.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentServices _departmentServices;
        public DepartmentsController(IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }

        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentServices.GetAll();
            return View(departments);
        }


        //public async Task<IActionResult> AddOrUpdate(GetAllPoliceOfficersViewModel model)
        //{
        //    await _departmentServices.AddOrUpdate(model);

        //    return RedirectToAction("Index", "Home");
        //}

        public async Task<IActionResult> Delete(long id)
        {
            await _departmentServices.Delete(id);

            return RedirectToAction(nameof(GetAll));
        }
    }
}
