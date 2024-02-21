using BLL;
using employeeCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace employeeCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var data = _employeeService.GetAllEmployees();
            return View(data);
        }

        public IActionResult Create()
        {

            ViewBag.Departments = _employeeService.GetDepartments();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel model)
        {
            ModelState.Remove("EmployeeId");
            if (ModelState.IsValid)
            {
                _employeeService.CreateEmployee(model);
                return RedirectToAction(nameof(Index));
            }
            // Same assumption about getting departments as above
            ViewBag.Departments = _employeeService.GetDepartments(); // Adjust this according to your actual implementation
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = _employeeService.GetEmployeeById(id);
            if (model == null)
            {
                return NotFound();
            }
            // Assuming the service method for departments as mentioned before
            ViewBag.Departments = _employeeService.GetDepartments(); // Adjust this according to your actual implementation
            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(model);
                return RedirectToAction("Index");
            }

            ViewBag.Departments = _employeeService.GetDepartments();
            return View("Create", model);
        }

        public IActionResult Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
