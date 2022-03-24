namespace MistyDashboard.ApplicationState
{
    public class AppState
    {
        public List<ConnectedRobot> robots;

        public AppState()
        {
            robots = new List<ConnectedRobot>();
        }

        public void addBot(ConnectedRobot botToAdd)
        {
            robots.Add(botToAdd);
        }

        public List<ConnectedRobot> getBots()
        {
            return robots;
        }
    }
}
