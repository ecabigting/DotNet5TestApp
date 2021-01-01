using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("ReturnDate")]
        public IActionResult ReturnDate() 
        {
            return CreatedAtAction("ReturnDate", DateTime.Now);
        }
    }
}
