using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MistyDashboard.ApplicationState;
using System.Text;

namespace MistyDashboard.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndTask : ControllerBase
    {

        private static readonly HttpClient client = new HttpClient();

        IAppState _appState;
        public EndTask(IAppState appState)
        {
            _appState = appState;
        }

        [HttpPost]
        public ActionResult Post()
        {
            _appState.setCurrentTask("none");


            List<ConnectedRobot> allBots = _appState.getBots();

            string returnVal = "success";

            if(allBots.Count < 1)
            {
                return Ok("noRobots");
            }

            foreach (var bot in allBots)
            {
                string uniqueId = "523c7187-706e-4313-a657-0fa11d8bbdd4";
                string botUrl = "http://" + bot.getIp() + "/api/skills/cancel";
                string myJson = "";
                var response = client.PostAsync(botUrl, new StringContent(myJson, Encoding.UTF8, "application/json")).Result;
                returnVal = response.ToString();
            }

            

            return Ok(returnVal);
        }

    }
}
