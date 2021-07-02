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

        [HttpGet]
        [Route("getemployee")]
        public IActionResult GetEmployee(string employeeId)
        {
            var res = employeeRepository.GetEmployee(employeeId);
            if (res == null)
            {
                return BadRequest("Cannot find employee");
            } else
            {
                return Ok(res);
            }
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
            if (employee.EmployeeId == null)
            {
                return BadRequest("Please enter a valid Employee Id.");
            }
            if (string.IsNullOrEmpty(employee.FirstName) || string.IsNullOrEmpty(employee.LastName))
            {
                return BadRequest("Employee first and last name must contain value.");
            }
            if (!employeeRepository.AddEmployee(employee))
            {
                return BadRequest("Employee Id aleady in use");
            }
            return Ok();
        }

        [HttpPut]
        [Route("updateemployee")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            var res = employeeRepository.UpdateEmployee(employee);
            if (!res)
            {
                return BadRequest("Cannot find employee");
            }
            else
            {
                return Ok(res);
            }
        }
    }
}
