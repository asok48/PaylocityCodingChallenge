using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitsCalculator.Data
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployees();
        public IEnumerable<Employee> GetFilteredEmployees(string id, string firstName, string LastName);
        public bool AddEmployee(Employee employee);
        public bool DeleteEmployee(Employee employee);
        public Employee EditEmployee(Employee employee);
    }
}
