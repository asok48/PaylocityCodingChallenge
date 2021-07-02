using System;
using System.Collections.Generic;
using System.Linq;

namespace BenefitsCalculator.Data
{
    public class DependentRepository : IDependentRepository
    {
        private BenefitsContext context;
        private const decimal DEPENDENT_COST = 500;
        private const decimal DISCOUNT = 0.9m;

        public DependentRepository(BenefitsContext _context)
        {
            context = _context;
        }

        public bool AddDependent(Dependent dependent)
        {
            if (context.Employees.Count(x => x.EmployeeId == dependent.EmployeeId) == 0)
            {
                return false;
            }

            dependent.Cost = dependent.FirstName.ToLower().StartsWith("a") ? DEPENDENT_COST * DISCOUNT : DEPENDENT_COST;
            try
            {
                context.Dependents.Add(dependent);
                context.SaveChanges();
            } catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Dependent> GetDependents(string employeeId)
        {
            return context.Dependents.Where(x => x.EmployeeId == employeeId).ToList();
        }

        public bool DeleteDependent(Dependent dependent)
        {
            if (context.Employees.Count(x => x.EmployeeId == dependent.EmployeeId) == 0)
            {
                return false;
            }
            try
            {
                context.Dependents.Remove(dependent);
                context.SaveChanges();
            } catch (Exception ex)
            {
                //Should ideally log expections instead of swallowing them
                return false;
            }
            return true;
        }

        public bool UpdateDependent(Dependent dependent)
        {
            var dbDependent = context.Dependents.FirstOrDefault(x => x.Id == dependent.Id);

            if (dbDependent == null)
            {
                return false;
            }

            dbDependent.FirstName = string.IsNullOrEmpty(dependent.FirstName) ? dbDependent.FirstName : dependent.FirstName;
            dbDependent.LastName = string.IsNullOrEmpty(dependent.LastName) ? dbDependent.LastName : dependent.LastName;
            dbDependent.Cost = dbDependent.FirstName.ToLower().StartsWith("a") ? DEPENDENT_COST * DISCOUNT : DEPENDENT_COST;

            try
            {
                context.Dependents.Update(dbDependent);
                context.SaveChanges();
            } catch (Exception ex)
            {
                return false;
            }
            return true;

        }

    }
}
