﻿namespace employeeCRUD.Models
{
    public class EmployeeViewModel
    {

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        //public string FirstName { get; set; }
        //public string LastName { get; set; }

        public string Address { get; set; }

        public int DepartmentId { get; set; }

        public string? DepartmentName { get; set; }
    }
}
