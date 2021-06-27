using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitsCalculator.Data
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployees();
        public bool AddEmployee(Employee employee);
        public bool AddDependent(Dependent dependent);
        public bool DeleteDependent(Dependent dependent);
    }
}
