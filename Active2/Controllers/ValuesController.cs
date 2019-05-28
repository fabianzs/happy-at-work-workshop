using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Active2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<bool> Get()
        {
            return Environment.GetEnvironmentVariable("ACTIVE") != "false";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] bool value)
        {
            Environment.SetEnvironmentVariable("ACTIVE", value.ToString());
        }
    }
}
