using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MistyDashboard.ApplicationState;

namespace MistyDashboard.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddRobot : ControllerBase
    {
        IAppState _appState;
        public AddRobot(IAppState appState)
        {
            _appState = appState;
        }

        [HttpPost]
        public ActionResult Post([FromBody] BotAddition botData)
        {
            System.Diagnostics.Debug.WriteLine("working....");    
            ConnectedRobot newBot = new ConnectedRobot(botData.Name, botData.Ip);
            _appState.addBot(newBot);

            string returnVal = "success";
            return Ok(returnVal);
        }
    }
}
