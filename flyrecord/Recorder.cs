using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flyrecord
{
    public sealed class Recorder
    {

        private static Video video;
        private static Size blockRegionSize;
        private static Point upperLeftSource;
        private readonly static Point upperLeftDestination = new Point(0, 0);
        private static int delay;
        private static Recorder instance = null;
        private static bool recording = false; 
        private static readonly object padlock = new object();
        private static Thread recordingThread;
        private static Bitmap bitmapBuffer;
        private static Graphics graphicsBuffer;

        public delegate void OnRecordStartEventHandler();
        public delegate void OnRecordStopCompleteEventHandler();
        public static event OnRecordStartEventHandler OnRecordStart;
        public static event OnRecordStopCompleteEventHandler OnRecordStopComplete;

        public static Recorder Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Recorder();
                    }
                    return instance;
                }
            }
        }

        public Recorder(){
            Countdown.OnTimeout += OnTimeoutEventHandler;
        }

        public bool Recording
        {
            get
            {
                return recording;
            }
        }

        private static void tick()
        {
            recording = true;
            while (recording) {
                graphicsBuffer.CopyFromScreen(upperLeftSource, upperLeftDestination, blockRegionSize);
                video.WriteFrame(bitmapBuffer);
                Thread.Sleep(delay);
            }
        }

        public void Stop() {
            //wait for the recording ends to continue avoiding bugs ;)
            recording = false;
            recordingThread.Join();

            video.Finish();
            Dispose();
            OnRecordStopComplete?.Invoke();
        }

        private void Dispose()
        {
            video = null;
            bitmapBuffer.Dispose();
            graphicsBuffer.Dispose();
        }

        public void Start(VideoFileFormat videoFileFormat, int frameRate, string outputPath) {
            Size blockRegionSize;

            //If EntireScreen option is set to true, get the user screen size
            if (Settings.Instance.EntireScreen)
                blockRegionSize = new Size(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
            else
            {
                Delimiter delimiter = Delimiter.Instance;
                delimiter.TopMost = true;
                blockRegionSize = delimiter.getInnerDelimiterSize();
                upperLeftSource = delimiter.getInnerDelimiterUpperLeftLocation();
                delimiter.Lock();
            }
            Recorder.blockRegionSize = blockRegionSize;
            video = Video.Create(videoFileFormat, frameRate, outputPath);
            delay = 1000 / frameRate;

            //Initialize buffers
            bitmapBuffer = new Bitmap(blockRegionSize.Width, blockRegionSize.Height);
            graphicsBuffer = Graphics.FromImage(bitmapBuffer);
            recordingThread = new Thread(tick);

            //Start countdown, when it is done it will start recording
            (new Countdown()).Show();
        }

        public void Start()
        {
            Settings instance = Settings.Instance;
            Start(instance.VideoFileFormat, 30, "./ola.gif");  
        }

        public void OnTimeoutEventHandler()
        {
            recordingThread.Start();
            OnRecordStart?.Invoke();
        }
    }
}
