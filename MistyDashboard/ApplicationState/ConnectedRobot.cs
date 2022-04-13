namespace MistyDashboard.ApplicationState
{
    public class ConnectedRobot
    {
        public string name = "";
        public string ipAddress = "";
        public string currentTask = "none";
        public Dictionary<string, string> taskIds;

        public ConnectedRobot(string newName, string newIp)
        {
            name = newName;
            ipAddress = newIp;
            taskIds = new Dictionary<string, string>();
        }

        public string getName()
        {
            return name;
        }

        public string getIp()
        {
            return ipAddress;
        }

        public void setTasks(Dictionary<string,string> newIds)
        {
            taskIds = newIds;
        }

        public Dictionary<string,string> getTasks()
        {
            return taskIds;
        }
    }
}
