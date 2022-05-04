/**************************************************************************
 * Class: ConnectedRobot                                                  *
 * Usage: Representation of single connected robot                        *
 *        * IP Adress                                                     *
 *        * Name                                                          *
 *        * Current Task Information                                      *
 *                                                                        *
 **************************************************************************/

namespace MistyDashboard.ApplicationState
{
    public class ConnectedRobot
    {
        //the name of the robot
        public string name = "";
        //the ip address of the robot
        public string ipAddress = "";
        //the list of tasks and their associeated unique ids
        public Dictionary<string, string> taskIds;

        //constructor that requires a name and an ip address. The taskIds list is left empty
        public ConnectedRobot(string newName, string newIp)
        {
            name = newName;
            ipAddress = newIp;
            taskIds = new Dictionary<string, string>();
        }

        //accessor for the name
        public string getName()
        {
            return name;
        }

        //accessor for the ip
        public string getIp()
        {
            return ipAddress;
        }

        //sets the list of unique Ids and task names to the argument
        public void setTasks(Dictionary<string,string> newIds)
        {
            taskIds = newIds;
        }

        //accessor for the taskIds dictionary
        public Dictionary<string,string> getTasks()
        {
            return taskIds;
        }
    }
}
