/**************************************************************************
 * Class: GetTaskInfo                                                     *
 * Usage: API controller that returns the TaskInfo string                 *
 *                                                                        *
 **************************************************************************/

//includes
using Microsoft.AspNetCore.Mvc;
using MistyDashboard.ApplicationState;

namespace MistyDashboard.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetTaskInfo : ControllerBase
    {
        //reference to the application's singleton application state object
        IAppState _appState;
        public GetTaskInfo(IAppState appState)
        {
            //dependency injection
            _appState = appState;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //the return value is simply the taskInfo value of the appState
            string returnVal = _appState.getTaskInfo();
            return Ok(returnVal);
        }
    }
}
