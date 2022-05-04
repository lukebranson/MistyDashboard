/**************************************************************************
 * Class: GetConnectedRobots                                              *
 * Usage: API controller that returns the list of connected robots        *
 *                                                                        *
 **************************************************************************/


//includes
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
        //reference to the application's singleton application state object
        IAppState _appState;
        public GetConnectedRobots(IAppState appState)
        {
            //dependency injection
            _appState = appState;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //the beginning of a json array
            string returnVal = "[";
            //this will be false if the following loop never runs
            bool botsExist = false;
            foreach (var bot in _appState.getBots())
            {
                //there is at least one bot
                botsExist = true;
                //add the bot object into the json return value string
                returnVal += ("{" + "\"name\": \"" + bot.getName() + "\",\"ip\": \"" + bot.getIp() + "\"},");
            }
            //if there are bots, get rid of the last comma
            if (botsExist)
            {
                returnVal = returnVal.Substring(0, returnVal.Length - 1);
            }
            //add the right bracket
            returnVal += "]";
            //exit
            return Ok(returnVal);
        }
    }
}
