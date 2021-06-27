using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenefitsCalculator.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BenefitsCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository repo, ILogger<EmployeeController> logger)
        {
            _logger = logger;
            employeeRepository = repo;
        }

        [HttpGet]
        [Route("getemployees")]
        public IActionResult Get()
        {

            return Ok(employeeRepository.GetEmployees());
        }

        [HttpPost]
        [Route("createemployee")]
        public IActionResult CreateEmployee(Employee employee)
        {
            if (!employeeRepository.AddEmployee(employee))
            {
                return BadRequest("Employee Id aleady in use");
            }
            return Ok();
        }

        [HttpPost]
        [Route("adddependent")]
        public IActionResult CreateDependent(Dependent dependent)
        {
            if (!employeeRepository.AddDependent(dependent))
            {
                return BadRequest("Error adding dependent");
            }
            return Ok(dependent);
        }

        [HttpPost]
        [Route("deletedependent")]
        public IActionResult DeleteDependent(Dependent dependent)
        {
            if (!employeeRepository.DeleteDependent(dependent))
            {
                return BadRequest("Error deleting dependent");
            }
            return Ok(dependent);
        }
    }
}
