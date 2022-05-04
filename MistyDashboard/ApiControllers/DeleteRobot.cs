/**************************************************************************
 * Class: DeleteRobot                                                        *
 * Usage: API controller that deletes robots from the application         *
 *                                                                        *
 **************************************************************************/


//includes
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
        //reference to the application's singleton application state object
        IAppState _appState;
        public DeleteRobot(IAppState appState)
        {
            //dependency injection
            _appState = appState;
        }

        [HttpPost]
        public ActionResult Post([FromBody] string botName)
        {
            //this will be returned if the deletion fails
            string returnVal = "failed";
            if (_appState.deleteBot(botName))
            {
                //switch the returnVal to success if the deletion worked
                returnVal = "success";
            }
            //success
            return Ok(returnVal);
        }
    }
}
