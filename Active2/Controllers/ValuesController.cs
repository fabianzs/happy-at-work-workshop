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
        bool active = true;

        // GET api/values
        [HttpGet]
        public ActionResult<bool> Get()
        {
            return active;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] bool value)
        {
            active = value;
        }
    }
}
