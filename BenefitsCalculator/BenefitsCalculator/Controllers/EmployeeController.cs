using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenefitsCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BenefitsCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("getemployee")]
        public IActionResult Get()
        {

            return Ok();
        }

        [HttpPost]
        [Route("createemployee")]
        public IActionResult CreateEmployee(Employee employee)
        {

            return Ok();
        }
    }
}
