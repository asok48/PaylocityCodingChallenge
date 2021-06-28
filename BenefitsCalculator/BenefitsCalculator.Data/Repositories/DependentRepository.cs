using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenefitsCalculator.Data
{
    public class DependentRepository : IDependentRepository
    {
        private BenefitsContext context;
        private const int DEPENDENT_COST = 500;
        private const double DISCOUNT = 0.9;

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
            context.Dependents.Add(dependent);
            context.SaveChanges();
            return true;
        }

        public bool DeleteDependent(Dependent dependent)
        {
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
