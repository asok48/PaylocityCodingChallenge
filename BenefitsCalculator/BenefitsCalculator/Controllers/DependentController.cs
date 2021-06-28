using BenefitsCalculator.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsCalculator.Controllers
{
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
