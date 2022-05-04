/**************************************************************************
 * Class: StartTask                                                        *
 * Usage: API controller that starts a Task on all connected robots       *
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
    public class StartTask : ControllerBase
    {
        //will be used to make the API call
        private static readonly HttpClient client = new HttpClient();

        //reference to the application's singleton application state object
        IAppState _appState;
        public StartTask(IAppState appState)
        {
            //dependency injection
            _appState = appState;
        }

        [HttpPost]
        public ActionResult Post([FromBody] string taskName)
        {
            //sets the current recorded task to the one that was set in the post body
            _appState.setCurrentTask(taskName);

            //this will be iterated through
            List<ConnectedRobot> allBots = _appState.getBots();

            //set this value to success for it to be changed if something fails
            string returnVal = "success";

            //return no robots if there are none
            if(allBots.Count < 1)
            {
                return Ok("noRobots");
            }
            //this keeps track of all the names of the robots that didn't have the tasks
            List<string> failedBots = new List<string>();
            foreach (var bot in allBots)
            {
                try
                {
                    //this will get the id needed for the api to run the task
                    string uniqueId = bot.getTasks()[taskName];
                    //generate the api url from the id
                    string botUrl = "http://" + bot.getIp() + "/api/skills/start" + "?skill=" + uniqueId;
                    //create the post body
                    string myJson = "{\"Skill\": \"" + uniqueId + "\",\"method\":null}";
                    //send the request
                    var response = client.PostAsync(botUrl, new StringContent(myJson, Encoding.UTF8, "application/json")).Result;
                    //returnVal = response.ToString();
                }
                catch(Exception ex)
                {
                    //if something fails, record that bot name in the failedBots list
                    failedBots.Add(bot.getName());
                }

            }
            //this sets the initial task info value
            _appState.setTaskInfo("task init");
            //exit
            return Ok(returnVal);
        }

    }
}
