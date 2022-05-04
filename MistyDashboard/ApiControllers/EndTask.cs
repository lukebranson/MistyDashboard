/**************************************************************************
 * Class: AddRobot                                                        *
 * Usage: API controller that stops the current task                      *
 *                                                                        *
 **************************************************************************/


//includes
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
        //will be used to make the API call
        private static readonly HttpClient client = new HttpClient();

        //reference to the application's singleton application state object
        IAppState _appState;
        public EndTask(IAppState appState)
        {
            //dependency injection
            _appState = appState;
        }

        [HttpPost]
        public ActionResult Post()
        {
            //set the current task to none
            _appState.setCurrentTask("none");

            //this list will be iterated through to call the stop api call on each bot
            List<ConnectedRobot> allBots = _appState.getBots();

            //this will be returned
            string returnVal = "success";

            //if there are no robots, just return "noRobots" for the reciever to handle
            if(allBots.Count < 1)
            {
                return Ok("noRobots");
            }

            //iterate through the list of bots
            foreach (var bot in allBots)
            {
                //build the api url
                string botUrl = "http://" + bot.getIp() + "/api/skills/cancel";
                //no data necessary
                string myJson = "";
                //send the request
                var response = client.PostAsync(botUrl, new StringContent(myJson, Encoding.UTF8, "application/json")).Result;
                //returnVal = response.ToString();
            }
            
            //exit
            return Ok(returnVal);
        }

    }
}
