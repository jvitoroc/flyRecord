using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flyrecord
{
    [System.Serializable]
    public sealed class Configuration
    {
        private string outputPath = "";
        private bool entireScreen = true;
        private bool followCursor = false;
        private int delimiterWidth = 0, delimiterHeight = 0;
        private VideoFileFormat videoFileFormat = VideoFileFormat.None;

        private static Configuration instance = null;
        private static readonly object padlock = new object();

        public Configuration()
        {

        }

        public static Configuration Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Configuration();
                        
                    }
                    return instance;
                }
            }

            set
            {
                instance = value;
            }
        }

        public void Reflect(FlyRecord flyRecord)
        {
            flyRecord.setControlSettings(outputPath, entireScreen, followCursor, delimiterWidth, DelimiterHeight, VideoFileFormat);
        }

        public bool FollowCursor { get => followCursor; set => followCursor = value; }
        public bool EntireScreen { get => entireScreen; set => entireScreen = value; }
        public string OutputPath { get => outputPath; set => outputPath = value; }
        public int DelimiterWidth { get => delimiterWidth; set => delimiterWidth = value; }
        public int DelimiterHeight { get => delimiterHeight; set => delimiterHeight = value; }
        public VideoFileFormat VideoFileFormat { get => videoFileFormat; set => videoFileFormat = value; }
    }
}
