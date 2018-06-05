using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace flyrecord
{
    [System.Serializable]
    public sealed class Settings
    {
        private string outputPath = "";
        private bool entireScreen = true;
        private bool followCursor = false;
        private int delimiterWidth = 0, delimiterHeight = 0;
        private VideoFileFormat videoFileFormat = VideoFileFormat.None;

        private static Settings instance = null;
        private static readonly object padlock = new object();

        public Settings(){ }

        // Create a local life that stores the current settings.
        // Or save the current settings in that file
        public void Sync()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs;
            if (!File.Exists(Program.SETTINGS_FILE_PATH))
            {
                fs = new FileStream(Program.SETTINGS_FILE_PATH, FileMode.Create);
                formatter.Serialize(fs, Settings.Instance);
            }
            else
            {
                fs = new FileStream(Program.SETTINGS_FILE_PATH, FileMode.Open);
                if (fs.Length != 0)
                    Settings.Instance = (Settings)formatter.Deserialize(fs);
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
        public VideoFileFormat VideoFileFormat { get => videoFileFormat; set => videoFileFormat = value; }
    }
}
