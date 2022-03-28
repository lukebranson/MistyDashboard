namespace MistyDashboard.ApplicationState
{
    public class ConnectedRobot
    {
        public string name = "";
        public string ipAddress = "";
        public string currentTask = "none";

        public ConnectedRobot(string newName, string newIp)
        {
            name = newName;
            ipAddress = newIp;
        }

        public string getName()
        {
            return name;
        }

        public string getIp()
        {
            return ipAddress;
        }
    }
}
