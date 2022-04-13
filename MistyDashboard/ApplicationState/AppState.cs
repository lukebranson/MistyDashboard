namespace MistyDashboard.ApplicationState
{

    public interface IAppState
    {
        void addBot(ConnectedRobot botToAdd);
        List<ConnectedRobot> getBots();
        List<String> getTasks();
        void addTasks(List<string> newTasks);
        string getCurrentTask();
        void setCurrentTask(string taskName);
        bool deleteBot(string nameToFind);
    }

    public class AppState : IAppState
    {
        public List<ConnectedRobot> robots;
        public List<string> tasks;
        public string currentTask;

        public AppState()
        {
            robots = new List<ConnectedRobot>();
            tasks = new List<string>();
            currentTask = "none";
        }

        public AppState(List<string> initTasks)
        {
            robots = new List<ConnectedRobot>();
            tasks = new List<string>();
            currentTask = "none";
            addTasks(initTasks);
        }

        public void addBot(ConnectedRobot botToAdd)
        {
            robots.Add(botToAdd);
        }

        public List<ConnectedRobot> getBots()
        {
            return robots;
        }

        public List<String> getTasks()
        {
            return tasks;
        }
        public void addTasks(List<string> newTasks)
        {
            tasks.AddRange(newTasks);
        }
        public string getCurrentTask()
        {
            return currentTask;
        }
        public void setCurrentTask(string taskName)
        {
            currentTask = taskName;
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
