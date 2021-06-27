using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenefitsCalculator.Data;
using BenefitsCalculator.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BenefitsCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly EmployeeRepository employeeRepository;
        public EmployeeController(EmployeeRepository repo, ILogger<EmployeeController> logger)
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
            var list = employeeRepository.AddEmployee(employee);
            return Ok();
        }
    }
}
