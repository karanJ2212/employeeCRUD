using DAL;
using DAL.Entities;
using employeeCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace employeeCRUD.Controllers
{
    public class DepartmentController : Controller
    {

        AppDBContext _db;

        public DepartmentController(AppDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var depts = _db.Departments.Select(p =>

            new DepartmentViewModel
            {
                DepartmentId = p.DepartmentId,
                DepartmentName = p.DepartmentName,
            }
            ).ToList();
            return View(depts);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Department dept = new Department
                {
                    DepartmentName = model.DepartmentName,
                };
                _db.Departments.Add(dept);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            DepartmentViewModel model = new DepartmentViewModel();

            // Find the department by ID
            var departmentData = _db.Departments.Find(id);


            if (departmentData != null)
            {
                model = new DepartmentViewModel
                {
                    DepartmentId = departmentData.DepartmentId,
                    DepartmentName = departmentData.DepartmentName
                };
            }
            else
            {

                return RedirectToAction("Index");
            }


            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create a new department object and map the properties
                Department department = new Department
                {
                    DepartmentId = model.DepartmentId,
                    DepartmentName = model.DepartmentName
                };

                // Update the department in the database
                _db.Departments.Update(department);
                _db.SaveChanges();


                return RedirectToAction("Index");
            }


            return View();
        }

        public IActionResult Delete(int id)
        {
            var model = _db.Departments.Find(id);
            if (model != null)
            {
                _db.Departments.Remove(model);
                _db.SaveChanges();

            }



            return RedirectToAction("Index");
        }



    }
}
