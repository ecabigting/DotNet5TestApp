using Hahn.ApplicatonProcess.December2020.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.RestAPI
{
    [Produces("application/json")]
    [Route("api/TestAPI")]
    public class TestAPI : Controller
    {
        ILogger _logger { get; }
        public TestAPI(ILogger<TestAPI> logger) 
        {
            _logger = logger;
        }

        [HttpGet("ReturnDate")]
        public IActionResult ReturnDate() 
        {
            _logger.LogInformation("Serilog is Alive!");
            return CreatedAtAction("ReturnDate", DateTime.Now);
        }

        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody] Employee _emp) 
        {
            return CreatedAtAction("AddEmployee",_emp);
        }
    }
}
