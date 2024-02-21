using DAL.Entities;
using employeeCRUD.Models;

namespace BLL
{
    public interface IEmployeeService
    {
        List<EmployeeViewModel> GetAllEmployees();
        void CreateEmployee(EmployeeViewModel employee);
        EmployeeViewModel GetEmployeeById(int id);
        void UpdateEmployee(EmployeeViewModel employee);
        void DeleteEmployee(int id);

        IEnumerable<Department> GetDepartments();
    }
}
