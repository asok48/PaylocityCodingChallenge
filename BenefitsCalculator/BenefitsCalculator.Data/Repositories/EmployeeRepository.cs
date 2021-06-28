using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenefitsCalculator.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private BenefitsContext context;
        private const int EMPLOYEE_COST = 1000;
        private const double DISCOUNT = 0.9;

        public EmployeeRepository(BenefitsContext _context)
        {
            context = _context;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees.AsNoTracking().ToList();
        }

        public bool AddEmployee(Employee employee)
        {
            if (context.Employees.Count(x => x.EmployeeId == employee.EmployeeId) > 0)
            {
                return false;
            }

            employee.Cost = employee.FirstName.ToLower().StartsWith("a") ? EMPLOYEE_COST * DISCOUNT : EMPLOYEE_COST;
            context.Employees.Add(employee);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Employee> GetFilteredEmployees(string id, string firstName, string lastName)
        {
            var res = context.Employees.AsNoTracking().ToList();
            if (!string.IsNullOrEmpty(id))
            {
                res = res.Where(x => x.EmployeeId.Contains(id)).ToList();
            }
            if (!string.IsNullOrEmpty(firstName))
            {
                res = res.Where(x => x.FirstName.Contains(firstName)).ToList();
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                res = res.Where(x => x.LastName.Contains(lastName)).ToList();
            }
            return res;
        }
        public Employee EditEmployee(Employee employee)
        {
            if (context.Employees.Count(x => x.EmployeeId == employee.EmployeeId) == 0)
            {
                return null;
            }

            var dbEmployee = context.Employees.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);
            if (dbEmployee == null)
            {
                return null;
            }

            dbEmployee.FirstName = employee.FirstName;
            dbEmployee.LastName = employee.LastName;

            context.Update(dbEmployee);
            return dbEmployee;
        }
        public bool DeleteEmployee(Employee employee)
        {
            var dbEmployee = context.Employees.AsNoTracking().SingleOrDefault(x => x.EmployeeId == employee.EmployeeId);
            if (dbEmployee == null)
            {
                return false;
            }
            context.Employees.Remove(employee);
            context.SaveChanges();
            return true;
        }
    }
}
