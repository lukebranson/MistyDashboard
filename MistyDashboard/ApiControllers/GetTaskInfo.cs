using Microsoft.AspNetCore.Mvc;
using MistyDashboard.ApplicationState;

namespace MistyDashboard.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetTaskInfo : ControllerBase
    {
        IAppState _appState;
        public GetTaskInfo(IAppState appState)
        {
            _appState = appState;
        }

        [HttpGet]
        public IActionResult Get()
        {
            string returnVal = _appState.getTaskInfo();
            return Ok(returnVal);
        }
    }
}
