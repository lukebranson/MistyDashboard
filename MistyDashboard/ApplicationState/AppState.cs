namespace MistyDashboard.ApplicationState
{

    public interface IAppState
    {
        void addBot(ConnectedRobot botToAdd);
        List<ConnectedRobot> getBots();
    }

    public class AppState : IAppState
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
