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
        private static readonly HttpClient client = new HttpClient();

        IAppState _appState;
        public AddRobot(IAppState appState)
        {
            _appState = appState;
        }

        [HttpPost]
        public ActionResult Post([FromBody] BotAddition botData)
        {
            string returnVal = "failed";
            Ping pingSender = new Ping();
            IPAddress ip;
            try
            {

                ip = IPAddress.Parse(botData.Ip);
            }

            catch (ArgumentNullException)
            {
                returnVal = "invalidIP";
                return Ok(returnVal);
            }

            catch (FormatException)
            {
                returnVal = "invalidIP";
                return Ok(returnVal);
            }

            catch (Exception)
            {
                returnVal = "invalidIP";
                return Ok(returnVal);
            }
            PingReply reply = pingSender.Send(ip);
            if (reply.Status == IPStatus.Success)
            {
                foreach (var botToCheck in _appState.getBots())
                {
                    if (botToCheck.getName() == botData.Name || botToCheck.getIp() == botData.Ip)
                    {
                        returnVal = "duplicateBot";
                        return Ok(returnVal);
                    }
                }
                //get tasks from bot
                string skillDataStr;
                Dictionary<string, string> newSkills = new Dictionary<string, string>();
                try
                {
                    string botUrl = "http://" + ip + "/api/skills";
                    var skillData = client.GetAsync(botUrl).Result;
                    if (!skillData.IsSuccessStatusCode)
                    {
                        returnVal = "notMisty";
                        return Ok(returnVal);
                    }
                    skillDataStr = skillData.Content.ReadAsStringAsync().Result;
                    var actualSkillData = JsonSerializer.Deserialize<SkillData>(skillDataStr);
                    foreach(var res in actualSkillData.result)
                    {
                        newSkills.Add(res.name, res.uniqueId);
                    }
                }
                catch
                {
                    returnVal = "notMisty";
                    return Ok(returnVal);
                }


                ConnectedRobot newBot = new ConnectedRobot(botData.Name, botData.Ip);
                newBot.setTasks(newSkills);
                _appState.addBot(newBot);
                //testIP: 10.12.132.44
                returnVal = "success";
                return Ok(returnVal);
            }
            else
            {
                returnVal = "notConnected";
            }
            return Ok(returnVal);
        }
    }
}
