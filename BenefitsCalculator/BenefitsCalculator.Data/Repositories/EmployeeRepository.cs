using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenefitsCalculator.Data.Repositories
{
    public class EmployeeRepository 
    {
        private BenefitsContext context;
        public EmployeeRepository(BenefitsContext _context)
        {
            context = _context;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees.ToList();
        }

        public bool AddEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            var list = context.Employees.ToList();
            return true;
        }
    }
}
