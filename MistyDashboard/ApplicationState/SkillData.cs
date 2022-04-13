using Newtonsoft.Json;

namespace MistyDashboard.ApplicationState
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ArduinoAssets
    {
    }

    public class AudioAssets
    {
        [JsonProperty("music.mp3")]
        public string MusicMp3 { get; set; }

        [JsonProperty("gameStart.mp3")]
        public string GameStartMp3 { get; set; }

        [JsonProperty("ilost.mp3")]
        public string IlostMp3 { get; set; }

        [JsonProperty("iwin.mp3")]
        public string IwinMp3 { get; set; }

        [JsonProperty("nicemove.mp3")]
        public string NicemoveMp3 { get; set; }

        [JsonProperty("ohno.mp3")]
        public string OhnoMp3 { get; set; }

        [JsonProperty("ropes.mp3")]
        public string RopesMp3 { get; set; }

        [JsonProperty("tile1.mp3")]
        public string Tile1Mp3 { get; set; }

        [JsonProperty("tile2.mp3")]
        public string Tile2Mp3 { get; set; }

        [JsonProperty("tile3.mp3")]
        public string Tile3Mp3 { get; set; }

        [JsonProperty("tile4.mp3")]
        public string Tile4Mp3 { get; set; }

        [JsonProperty("tile5.mp3")]
        public string Tile5Mp3 { get; set; }

        [JsonProperty("tile6.mp3")]
        public string Tile6Mp3 { get; set; }

        [JsonProperty("tile7.mp3")]
        public string Tile7Mp3 { get; set; }

        [JsonProperty("tile8.mp3")]
        public string Tile8Mp3 { get; set; }

        [JsonProperty("tile9.mp3")]
        public string Tile9Mp3 { get; set; }

        [JsonProperty("draw.mp3")]
        public string DrawMp3 { get; set; }
    }

    public class ImageAssets
    {
        [JsonProperty("gameover.jpg")]
        public string GameoverJpg { get; set; }

        [JsonProperty("images2.png")]
        public string Images2Png { get; set; }

        [JsonProperty("otoe.png")]
        public string OtoePng { get; set; }

        [JsonProperty("otoe2.png")]
        public string Otoe2Png { get; set; }

        [JsonProperty("otoe3.png")]
        public string Otoe3Png { get; set; }

        [JsonProperty("otoe4.png")]
        public string Otoe4Png { get; set; }

        [JsonProperty("otoe5.png")]
        public string Otoe5Png { get; set; }

        [JsonProperty("otoe6.png")]
        public string Otoe6Png { get; set; }

        [JsonProperty("otoe7.png")]
        public string Otoe7Png { get; set; }

        [JsonProperty("otoe8.png")]
        public string Otoe8Png { get; set; }

        [JsonProperty("otoe9.png")]
        public string Otoe9Png { get; set; }

        [JsonProperty("player1wins.png")]
        public string Player1winsPng { get; set; }

        [JsonProperty("player2Wins.png")]
        public string Player2WinsPng { get; set; }

        [JsonProperty("theX.png")]
        public string TheXPng { get; set; }

        [JsonProperty("tieGame.png")]
        public string TieGamePng { get; set; }

        [JsonProperty("xtoe.png")]
        public string XtoePng { get; set; }

        [JsonProperty("xtoe2.png")]
        public string Xtoe2Png { get; set; }

        [JsonProperty("xtoe3.png")]
        public string Xtoe3Png { get; set; }

        [JsonProperty("xtoe4.png")]
        public string Xtoe4Png { get; set; }

        [JsonProperty("xtoe5.png")]
        public string Xtoe5Png { get; set; }

        [JsonProperty("xtoe6.png")]
        public string Xtoe6Png { get; set; }

        [JsonProperty("xtoe7.png")]
        public string Xtoe7Png { get; set; }

        [JsonProperty("xtoe8.png")]
        public string Xtoe8Png { get; set; }

        [JsonProperty("xtoe9.png")]
        public string Xtoe9Png { get; set; }

        [JsonProperty("blankBoard.png")]
        public string BlankBoardPng { get; set; }

        [JsonProperty("blankBoard2.png")]
        public string BlankBoard2Png { get; set; }

        [JsonProperty("blankBoardBlack.jpg")]
        public string BlankBoardBlackJpg { get; set; }
    }

    public class IpFilter
    {
    }

    public class Parameters
    {
        public int @int { get; set; }
        public double @double { get; set; }
        public string @string { get; set; }
        public string apikeY_GoogleSTT { get; set; }
        public string apikeY_GoogleTTS { get; set; }
    }

    public class Result
    {
        public int allowedCleanupTimeInMs { get; set; }
        public ArduinoAssets arduinoAssets { get; set; }
        public AudioAssets audioAssets { get; set; }
        public string broadcastMode { get; set; }
        public List<object> capabilities { get; set; }
        public bool cleanupOnCancel { get; set; }
        public string description { get; set; }
        public bool displaySkill { get; set; }
        public bool forceCancelSkill { get; set; }
        public ImageAssets imageAssets { get; set; }
        public IpFilter ipFilter { get; set; }
        public string language { get; set; }
        public string name { get; set; }
        public List<object> needs { get; set; }
        public Parameters parameters { get; set; }
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
