/**************************************************************************
 * Class: SetTaskInfo                                                     *
 * Usage: API controller that sets the TaskInfo string                    *
 *                                                                        *
 **************************************************************************/

//includes
using Microsoft.AspNetCore.Mvc;
using MistyDashboard.ApplicationState;

namespace MistyDashboard.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SetTaskInfo : ControllerBase
    {
        //reference to the application's singleton application state object
        IAppState _appState;
        public SetTaskInfo(IAppState appState)
        {
            //dependency injection
            _appState = appState;
        }

        [HttpPost]
        public IActionResult Post([FromBody] string newData)
        {
            //grab the string from the request body and set the TaskInfo string equal to it
            _appState.setTaskInfo(newData);
            //return the new value
            string returnVal = _appState.getTaskInfo();
            return Ok(returnVal);
        }
    }
}
