using DAL;
using DAL.Entities;
using employeeCRUD.Models;

namespace BLL
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDBContext _db;

        public EmployeeService(AppDBContext db)
        {
            _db = db;
        }

        public List<EmployeeViewModel> GetAllEmployees()
        {
            return (from e in _db.Employees
                    join d in _db.Departments on e.DepartmentId equals d.DepartmentId
                    select new EmployeeViewModel
                    {
                        EmployeeId = e.EmployeeId,
                        EmployeeName = e.EmployeeName,
                        Address = e.Address,
                        DepartmentId = e.DepartmentId,
                        DepartmentName = d.DepartmentName
                    }).ToList();
        }

        public void CreateEmployee(EmployeeViewModel model)
        {
            var employee = new Employee
            {
                EmployeeName = model.EmployeeName,
                //firstName = model.firstName,
                //lastName = model.lastName,

                Address = model.Address,
                DepartmentId = model.DepartmentId,


            };
            _db.Add(employee);
            _db.SaveChanges();
        }

        public EmployeeViewModel GetEmployeeById(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee != null)
            {
                return new EmployeeViewModel
                {
                    EmployeeId = employee.EmployeeId,
                    EmployeeName = employee.EmployeeName,
                    Address = employee.Address,
                    DepartmentId = employee.DepartmentId,
                    DepartmentName = _db.Departments.Where(d => d.DepartmentId == employee.DepartmentId).Select(d => d.DepartmentName).FirstOrDefault()
                };
            }
            return null;
        }

        public void UpdateEmployee(EmployeeViewModel model)
        {
            var employee = new Employee
            {
                EmployeeId = model.EmployeeId,
                EmployeeName = model.EmployeeName,
                Address = model.Address,
                DepartmentId = model.DepartmentId
            };
            _db.Employees.Update(employee);
            _db.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee != null)
            {
                _db.Employees.Remove(employee);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _db.Departments.ToList();
        }
    }
}
