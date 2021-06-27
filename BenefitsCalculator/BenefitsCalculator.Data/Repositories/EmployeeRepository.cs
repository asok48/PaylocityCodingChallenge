using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenefitsCalculator.Data
{
    public class EmployeeRepository : IEmployeeRepository
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
            if (context.Employees.Count(x => x.EmployeeId == employee.EmployeeId) > 0)
            {
                return false;
            }
            context.Employees.Add(employee);
            context.SaveChanges();
            return true;
        }

        public bool AddDependent(Dependent dependent)
        {
            if (context.Employees.Count(x => x.EmployeeId == dependent.EmployeeId) == 0)
            {
                return false;
            }
            context.Dependents.Add(dependent);
            context.SaveChanges();
            return true;
        }

        public bool DeleteDependent(Dependent dependent) {
            if (context.Employees.Count(x => x.EmployeeId == dependent.EmployeeId) == 0)
            {
                return false;
            }
            context.Dependents.Remove(dependent);
            context.SaveChanges();
            return true;
        }
    }
}
