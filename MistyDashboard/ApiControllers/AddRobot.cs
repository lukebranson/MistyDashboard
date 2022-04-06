using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MistyDashboard.ApplicationState;
using System.Net.NetworkInformation;
using System.Text;
using System.Net;

namespace MistyDashboard.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddRobot : ControllerBase
    {
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

            catch (ArgumentNullException e)
            {
                returnVal = "invalidIP";
                return Ok(returnVal);
            }

            catch (FormatException e)
            {
                returnVal = "invalidIP";
                return Ok(returnVal);
            }

            catch (Exception e)
            {
                returnVal = "invalidIP";
                return Ok(returnVal);
            }
            PingReply reply = pingSender.Send(ip);
            if (reply.Status == IPStatus.Success)
            {
                
                foreach(var botToCheck in _appState.getBots())
                {
                    if(botToCheck.getName() == botData.Name || botToCheck.getIp() == botData.Ip)
                    {
                        returnVal = "duplicateBot";
                        return Ok(returnVal);
                    }
                }
                System.Diagnostics.Debug.WriteLine("working....");
                ConnectedRobot newBot = new ConnectedRobot(botData.Name, botData.Ip);
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
