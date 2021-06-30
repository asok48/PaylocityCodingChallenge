using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitsCalculator.Data
{
    public interface IDependentRepository
    {
        public bool AddDependent(Dependent dependent);
        public IEnumerable<Dependent> GetDependents(string employeeId);
        public bool DeleteDependent(Dependent dependent);
    }
}