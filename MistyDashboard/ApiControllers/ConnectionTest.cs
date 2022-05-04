/**************************************************************************
 * Class: ConnectionTest                                                  *
 * Usage: Useful for testing if the dashboard is online                   *
 *                                                                        *
 **************************************************************************/

//includes
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
            //log the successful connection
            System.Diagnostics.Debug.WriteLine("connection successful");
            //send back a success message
            return Ok("success");
        }
    }
}
