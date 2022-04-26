using Microsoft.AspNetCore.Mvc;
using MistyDashboard.ApplicationState;

namespace MistyDashboard.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SetTaskInfo : ControllerBase
    {
        IAppState _appState;
        public SetTaskInfo(IAppState appState)
        {
            _appState = appState;
        }

        [HttpPost]
        public IActionResult Post([FromBody] string newData)
        {
            _appState.setTaskInfo(newData);
            string returnVal = _appState.getTaskInfo();
            return Ok(returnVal);
        }
    }
}
