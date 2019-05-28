using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleRestApi.Model;

namespace SimpleRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SimpleDateTimeController : ControllerBase
    {
        // GET api/simpledatetime
        [HttpGet]
        public ActionResult<SimpleDateTimeResponse> Get()
        {
            return new SimpleDateTimeResponse { CurrentDateTime = DateTime.Now };
        }

      
    }
}
