using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace flyrecord
{
    [System.Serializable]
    public sealed class Settings
    {
        private string outputPath = "";
        private bool entireScreen = true;
        private bool followCursor = false;
        private int delimiterWidth = 0, delimiterHeight = 0;
        private float frameRate = 15;
        private int frameRateIndex = 0;

        private static Settings instance = null;
        private static readonly object padlock = new object();

        public Settings(){
            
        }

        // Create a local life that stores the current settings.
        // Or save the current settings in that file
        public void Sync(bool save = false)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs;
            if (!File.Exists(Program.SETTINGS_FILE_PATH))
            {
                fs = new FileStream(Program.SETTINGS_FILE_PATH, FileMode.Create);
                formatter.Serialize(fs, Instance);
            }
            else
            {
                if (save)
                {
                    fs = new FileStream(Program.SETTINGS_FILE_PATH, FileMode.Truncate);
                    formatter.Serialize(fs, Instance);
                }
                else
                {
                    fs = new FileStream(Program.SETTINGS_FILE_PATH, FileMode.Open);
                    if (fs.Length != 0)
                        Instance = (Settings)formatter.Deserialize(fs);
                }
            }
            fs.Dispose();
            fs.Close();
            formatter = null;
        }

        public static Settings Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Settings();
                        
                    }
                    return instance;
                }
            }

            set
            {
                instance = value;
            }
        }

        public bool FollowCursor { get => followCursor; set => followCursor = value; }
        public bool EntireScreen { get => entireScreen; set => entireScreen = value; }
        public string OutputPath { get => outputPath; set => outputPath = value; }
        public int DelimiterWidth { get => delimiterWidth; set => delimiterWidth = value; }
        public int DelimiterHeight { get => delimiterHeight; set => delimiterHeight = value; }
        public float FrameRate { get => frameRate; set => frameRate = value; }
        public int FrameRateIndex { get => frameRateIndex; set => frameRateIndex = value; }
    }
}
