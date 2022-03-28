using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MistyDashboard.ApplicationState;

namespace MistyDashboard.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddDebugBot : ControllerBase
    {
        IAppState _appState;
        public AddDebugBot(IAppState appState)
        {
            _appState = appState;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]string name,[FromQuery]string ip)
        {
            ConnectedRobot newBot = new ConnectedRobot(name,ip);
            _appState.addBot(newBot);

            string returnVal = "bot added: "+name+", " +ip;
            return Ok(returnVal);
        }
    }
}
