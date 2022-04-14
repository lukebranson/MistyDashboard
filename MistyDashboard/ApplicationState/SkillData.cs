﻿using Newtonsoft.Json;

namespace MistyDashboard.ApplicationState
{

    public class Result
    {
        public int allowedCleanupTimeInMs { get; set; }
        public string broadcastMode { get; set; }
        public List<object> capabilities { get; set; }
        public bool cleanupOnCancel { get; set; }
        public string description { get; set; }
        public bool displaySkill { get; set; }
        public bool forceCancelSkill { get; set; }
        public string language { get; set; }
        public string name { get; set; }
        public List<object> needs { get; set; }
        public object priority { get; set; }
        public List<object> readPermissions { get; set; }
        public List<object> relevances { get; set; }
        public string skillStorageLifetime { get; set; }
        public List<object> startPermissions { get; set; }
        public List<string> startupRules { get; set; }
        public int timeoutInSeconds { get; set; }
        public List<object> triggerPermissions { get; set; }
        public string uniqueId { get; set; }
        public string version { get; set; }
        public List<object> writePermissions { get; set; }
        public bool writeToLog { get; set; }
    }

    public class SkillData
    {
        public List<Result> result { get; set; }
        public string status { get; set; }
    }


}
