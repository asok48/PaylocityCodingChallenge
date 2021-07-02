using System;
using System.Collections.Generic;

namespace BenefitsCalculator.Models
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeId { get; set; }
        public IEnumerable<Dependent> Dependents { get; set; }
    }
}
