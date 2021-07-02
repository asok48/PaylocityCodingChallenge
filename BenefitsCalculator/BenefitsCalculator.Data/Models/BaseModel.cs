using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitsCalculator.Data
{
    public class BaseModel
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
