using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MistyDashboard.ApplicationState;
using System.Net.NetworkInformation;
using System.Text;
using System.Net;

namespace MistyDashboard.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeleteRobot : ControllerBase
    {
        IAppState _appState;
        public DeleteRobot(IAppState appState)
        {
            _appState = appState;
        }

        [HttpPost]
        public ActionResult Post([FromBody] string botName)
        {
            string returnVal = "failed";
            if (_appState.deleteBot(botName))
            {
                returnVal = "success";
            }
            return Ok(returnVal);
        }
    }
}
