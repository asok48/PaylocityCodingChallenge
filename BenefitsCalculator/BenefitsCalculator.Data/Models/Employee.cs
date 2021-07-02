using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitsCalculator.Data
{
    public class Employee : BaseModel
    {
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Cost { get; set; }

    }
}
