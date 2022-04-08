namespace MistyDashboard.ApplicationState
{

    public interface IAppState
    {
        void addBot(ConnectedRobot botToAdd);
        List<ConnectedRobot> getBots();
        bool deleteBot(string nameToFind);
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

        public bool deleteBot(string nameToFind)
        {
            bool deleted = false;
            for (int i = robots.Count - 1; i >= 0; i--)
            {
                if (robots[i].getName() == nameToFind)
                {
                    robots.RemoveAt(i);
                    deleted = true;
                }
            }
            return deleted;
        }
    }
}
