using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MistyDashboard.ApplicationState;

namespace MistyDashboard.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetConnectedRobots : ControllerBase
    {
        IAppState _appState;
        public GetConnectedRobots(IAppState appState)
        {
            _appState = appState;
        }

        [HttpGet]
        public IActionResult Get()
        {
            string returnVal = "[";
            bool botsExist = false;
            foreach (var bot in _appState.getBots())
            {
                botsExist = true;
                returnVal += ("{" + "\"name\": \"" + bot.getName() + "\",\"ip\": \"" + bot.getIp() + "\"},");
                System.Diagnostics.Debug.WriteLine(bot.getName());
            }
            if (botsExist)
            {
                returnVal = returnVal.Substring(0, returnVal.Length - 1);
            }
            returnVal += "]";
            return Ok(returnVal);
        }
    }
}
