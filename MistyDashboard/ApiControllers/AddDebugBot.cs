/**************************************************************************
 * Class: AddDebugBot                                                     *
 * Usage: Adds mock robots into the application for UI testing purposes.  *
 *        Currently disabled.                                             *
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
    public class AddDebugBot : ControllerBase
    {
        //instance variable that will reference the singleton application state
        IAppState _appState;
        public AddDebugBot(IAppState appState)
        {
            //set the appState instance variable to the injected appState
            _appState = appState;
        }

        //uses get so as to make this easy to accomplish in a browswer window
        [HttpGet]
        public IActionResult Get([FromQuery]string name,[FromQuery]string ip)
        {
            //returns early to make this task impossible. if you would like to perform this api call, comment out the next line
            //return Ok("debug additions are currently disabled");
            //create the new bot and add it
            ConnectedRobot newBot = new ConnectedRobot(name,ip);
            _appState.addBot(newBot);
            //return the name and ip of the added bot
            string returnVal = "bot added: "+name+", " +ip;
            return Ok(returnVal);
        }
    }
}
