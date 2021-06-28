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

        [HttpGet]
        [Route("filteremployees")]
        public IActionResult GetFiltered(string id, string firstName, string lastName)
        {

            return Ok(employeeRepository.GetFilteredEmployees(id, firstName, lastName));
        }

        [HttpPost]
        [Route("deleteemployee")]
        public IActionResult DeleteEmployee(Employee employee)
        {
            if (!employeeRepository.DeleteEmployee(employee))
            {
                return BadRequest("Error deleting employee record.");
            } else
            {
                return Ok();
            }
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

        [HttpPut]
        [Route("editemployee")]
        public IActionResult EditEmployee(Employee employee)
        {
            var res = employeeRepository.EditEmployee(employee);
            return Ok(res);
        }
    }
}
