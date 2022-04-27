/**************************************************************************
 * Class: AddRobot                                                        *
 * Usage: API controller that adds robots to the application              *
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
using System.Text.Json;

namespace MistyDashboard.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddRobot : ControllerBase
    {
        //this will be used to make external api calls
        private static readonly HttpClient client = new HttpClient();

        //will be a reference to the singleton application state
        IAppState _appState;
        public AddRobot(IAppState appState)
        {
            //set the appState instance variable to the injected appState
            _appState = appState;
        }

        //this function actually accepts the post request
        [HttpPost]
        public ActionResult Post([FromBody] BotAddition botData)
        {
            //this string will be returned at the end of the operation.
            //we set it to "failed" and change it when the method succeeds
            string returnVal = "failed";
            //this will store the ip address the user submitted in the post body
            IPAddress ip;
            //first we try to parse the ip address
            try
            {

                ip = IPAddress.Parse(botData.Ip);
            }
            //if there is no ip address, return "invalidIP"
            catch (ArgumentNullException)
            {
                returnVal = "error: no IP address";
                return Ok(returnVal);
            }
            //if the ip address is improperly formatted, return "invalidIP"
            catch (FormatException)
            {
                returnVal = "error: invalid IP address";
                return Ok(returnVal);
            }
            //this handles all other exceptions
            catch (Exception)
            {
                returnVal = "error: invalid IP address";
                return Ok(returnVal);
            }
            //this loop checks to make sure that the name and ip address don't already exist in the list of robots
            foreach (var botToCheck in _appState.getBots())
            {
                //if a duplicate bot name or ip address is found, the function will return "duplicateBot"
                if (botToCheck.getName() == botData.Name || botToCheck.getIp() == botData.Ip)
                {
                    returnVal = "duplicateBot";
                    return Ok(returnVal);
                }
            }
            //this string will hold the skilldata retrieved from the robot once it is added
            string skillDataStr;
            //this will hold all of the robot's skills and their associated unique IDs
            //the unique IDs are required to run a skill and vary between robots
            Dictionary<string, string> newSkills = new Dictionary<string, string>();
            try
            {
                //this is the url of the api call to get the list of skills held by the robot
                string botUrl = "http://" + ip + "/api/skills";
                //this gets the skills from the bot and stores it in the skillData variable
                HttpResponseMessage skillData = client.GetAsync(botUrl).Result;
                //if the call was not successful, the ip address may not belong to a Misty Bot
                if (!skillData.IsSuccessStatusCode)
                {
                    returnVal = "error: failed to load robot information";
                    return Ok(returnVal);
                }
                //Dr Blythe, please tell me if you saw this. if you did, God bless you for reading all of this code -Luke
                //turn the httpresponsemessage into a string
                skillDataStr = skillData.Content.ReadAsStringAsync().Result;
                //turn the string into a SkillData object
                var actualSkillData = JsonSerializer.Deserialize<SkillData>(skillDataStr);
                //for every skill in the skilldata object, add it to the dictionary
                foreach(var res in actualSkillData.result)
                {
                    newSkills.Add(res.name, res.uniqueId);
                }
            }
            //if something didn't work, return the error
            catch
            {
                returnVal = "error: failed to request robot information";
                return Ok(returnVal);
            }

            //if all of the above magically worked, create a new ConnectedRobot object out of the name and ip
            ConnectedRobot newBot = new ConnectedRobot(botData.Name, botData.Ip);
            //add the dictionary of tasks to the robot
            newBot.setTasks(newSkills);
            //add the robot to the application state
            _appState.addBot(newBot);
            //the only way the try section of this code would fail is if the robot turned off at this instant.
            //still, it is better safe than sorry
            try
            {
                //create the url to change the robots light color
                string botUrl = "http://" + ip + "/api/led?red=0&green=255&blue=0";
                //make the api call to change the color
                var response = client.PostAsync(botUrl, new StringContent("", Encoding.UTF8, "application/json")).Result;
                //if the robot fails, return the error
                if (!response.IsSuccessStatusCode)
                {
                    returnVal = "error: failed to initialize robot light";
                    return Ok(returnVal);
                }
                //create the url to play the success sound
                botUrl = "http://" + ip + "/api/audio/play";
                //create the json needed to play the success audio file. This audio file exists on mistys out of the box
                string audioString = "{ \"fileName\":\"033-Ya.wav\",\"volume\":100 }";
                //play the success audio
                response = client.PostAsync(botUrl, new StringContent(audioString, Encoding.UTF8, "application/json")).Result;
                //if this failed, tell the user
                if (!response.IsSuccessStatusCode)
                {
                    returnVal = "error: failed to initialize robot sounds";
                    return Ok(returnVal);
                }
            }
            //if the api request failed, tell the user
            catch
            {
                returnVal = "error: failed to start initialization feedback";
                return Ok(returnVal);
            }
            //if everything worked, return success
            returnVal = "success";
            return Ok(returnVal);
        }
    }
}
