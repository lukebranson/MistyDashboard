using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MistyDashboard.ApplicationState;
using System.Text;

namespace MistyDashboard.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StartTask : ControllerBase
    {

        private static readonly HttpClient client = new HttpClient();

        IAppState _appState;
        public StartTask(IAppState appState)
        {
            _appState = appState;
        }

        [HttpPost]
        public ActionResult Post([FromBody] string taskName)
        {
            _appState.setCurrentTask(taskName);


            List<ConnectedRobot> allBots = _appState.getBots();

            string returnVal = "success";

            if(allBots.Count < 1)
            {
                return Ok("noRobots");
            }

            foreach (var bot in allBots)
            {
                string uniqueId = bot.getTasks()[taskName];
                string botUrl = "http://" + bot.getIp() + "/api/skills/start" + "?skill=" + uniqueId;
                string myJson = "{\"Skill\": \"" + uniqueId + "\",\"method\":null}";
                var response = client.PostAsync(botUrl, new StringContent(myJson, Encoding.UTF8, "application/json")).Result;
                //returnVal = response.ToString();
            }

            _appState.setTaskInfo("task init");

            return Ok(returnVal);
        }

    }
}
