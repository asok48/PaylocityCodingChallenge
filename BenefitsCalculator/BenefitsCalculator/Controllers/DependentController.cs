using BenefitsCalculator.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DependentController : ControllerBase
    {
        private readonly ILogger<DependentController> _logger;
        private readonly IDependentRepository dependentRepository;

        public DependentController(IDependentRepository repo, ILogger<DependentController> logger)
        {
            _logger = logger;
            dependentRepository = repo;
        }

        [HttpPost]
        [Route("adddependent")]
        public IActionResult CreateDependent(Dependent dependent)
        {
            if (!dependentRepository.AddDependent(dependent))
            {
                return BadRequest("Error adding dependent");
            }
            return Ok(dependent);
        }

        [HttpGet]
        [Route("getdependents")]
        public IActionResult GetDependents(string employeeId)
        {
            if (string.IsNullOrEmpty(employeeId))
            {
                return BadRequest("Invalid employee Id");
            }
            return Ok(dependentRepository.GetDependents(employeeId));
        }

        [HttpPost]
        [Route("deletedependent")]
        public IActionResult DeleteDependent(Dependent dependent)
        {
            if (!dependentRepository.DeleteDependent(dependent))
            {
                return BadRequest("Error deleting dependent");
            }
            return Ok(dependent);
        }
    }
}
