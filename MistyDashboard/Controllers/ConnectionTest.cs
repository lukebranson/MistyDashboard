using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace MistyDashboard.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConnectionTest : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("test");
        }
    }
}
