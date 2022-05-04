/**************************************************************************
 * Class: AppState                                                        *
 * Usage: Representation of the status of the application including       *
 *        * Connected Bots                                                *
 *        * Current Task                                                  *
 *        * Current Task Information                                      *
 *                                                                        *
 **************************************************************************/

namespace MistyDashboard.ApplicationState
{

    //public interface to make this a service that can be injected into controllers
    public interface IAppState
    {
        //adds a robot to the list of connected robots
        void addBot(ConnectedRobot botToAdd);

        //returns a list of connected robots
        List<ConnectedRobot> getBots();

        //returns a list of known tasks
        List<String> getTasks();

        //adds to the list of known tasks
        void addTasks(List<string> newTasks);

        //returns the current running task
        string getCurrentTask();

        //sets the current running task
        void setCurrentTask(string taskName);

        //removes a bot by name from the list of connected robots
        bool deleteBot(string nameToFind);

        //sets the taskInfo string
        string setTaskInfo(string newTaskInfo);

        //gets the taskInfo string
        string getTaskInfo();

    }

    public class AppState : IAppState
    {
        //the list of the connected robots
        public List<ConnectedRobot> robots;
        //the list of known possible tasks
        public List<string> tasks;
        //the current running task
        public string currentTask;
        //a string holding modifiable information about the current task
        public string taskInfo;

        //constructor that sets all values to their initial state
        public AppState()
        {
            //creates an empty list for the connected robots
            robots = new List<ConnectedRobot>();
            //creates an empty list for the known tasks
            tasks = new List<string>();
            //no current task
            currentTask = "none";
            //initial information for taskInfo
            taskInfo = "task init";
        }

        //constructor that sets all values to their initial state and automatically sets a list of tasks
        public AppState(List<string> initTasks)
        {
            //creates an empty list for the connected robots
            robots = new List<ConnectedRobot>();
            //creates an empty list for the known tasks
            tasks = new List<string>();
            //no current task
            currentTask = "none";
            //initial information for taskInfo
            taskInfo = "no current task";
            //add tasks passed in argument
            addTasks(initTasks);
        }

        //adds a robot to the list of connected robots
        public void addBot(ConnectedRobot botToAdd)
        {
            robots.Add(botToAdd);
        }

        //returns a list of connected robots
        public List<ConnectedRobot> getBots()
        {
            return robots;
        }

        //returns a list of known tasks
        public List<String> getTasks()
        {
            return tasks;
        }

        //adds to the list of known tasks
        public void addTasks(List<string> newTasks)
        {
            tasks.AddRange(newTasks);
        }

        //returns the current running task
        public string getCurrentTask()
        {
            return currentTask;
        }

        //sets the current running task
        public void setCurrentTask(string taskName)
        {
            currentTask = taskName;
        }

        //removes a bot by name from the list of connected robots
        public bool deleteBot(string nameToFind)
        {
            //this will be changed to true if the bot name exists
            bool deleted = false;
            for (int i = robots.Count - 1; i >= 0; i--)
            {
                //check if the current bot has the name we are looking fore
                if (robots[i].getName() == nameToFind)
                {
                    //remove the bot if it is found
                    robots.RemoveAt(i);
                    //update this to show the deletion worked
                    deleted = true;
                }
            }
            return deleted;
        }

        //sets the taskInfo string
        public string setTaskInfo(string newTaskInfo)
        {
            taskInfo = newTaskInfo;
            return taskInfo;
        }

        //gets the taskInfo string
        public string getTaskInfo()
        {
            return taskInfo;
        }
    }
}
