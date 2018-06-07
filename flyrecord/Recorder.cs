using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
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
        private static Size blockRegionSize;
        private static Point upperLeftSource;
        private readonly static Point upperLeftDestination = new Point(0, 0);
        private static int delay;
        private static Recorder instance = null;
        private static bool recording = false; 
        private static readonly object padlock = new object();
        private static VideoFileFormat videoFileFormat;

        private static Thread streamWriterThread;

        private static Bitmap bitmapBuffer;
        private static Graphics graphicsBuffer;
        private static List<Bitmap> frames;

        private static Stopwatch stopWatch;

        private static int totalFrames;

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

        private static void streamWriter()
        {
            stopWatch.Start();
            while (recording) {
                graphicsBuffer.CopyFromScreen(upperLeftSource, upperLeftDestination, blockRegionSize);
                frames.Add(bitmapBuffer);
                totalFrames += 1;
                Thread.Sleep(delay);
            }
            stopWatch.Stop();
        }

        public void Stop() {
            recording = false;
            //wait for the recording threads to end
            streamWriterThread.Join();

            Video video = Video.Create(videoFileFormat);
            int realDelay = (int)stopWatch.ElapsedMilliseconds / totalFrames;

            video.SaveStream(frames, realDelay, "./ola.gif");
            video = null;

            Dispose();
            OnRecordStopComplete?.Invoke();
        }

        private void Dispose(){
            frames = null;
            bitmapBuffer.Dispose();
            graphicsBuffer.Dispose();
            streamWriterThread = null;
            totalFrames = 0;
            elapsedMs = 0;
        }

        public void Start(VideoFileFormat videoFileFormat, int frameRate, string outputPath) {
            Size blockRegionSize;
            Recorder.videoFileFormat = videoFileFormat;

            //If EntireScreen option is set to true, get the user screen size
            if (Settings.Instance.EntireScreen)
                blockRegionSize = new Size(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
            else
            {

                Delimiter delimiter = Delimiter.Instance;
                delimiter.Lock();
                delimiter.TopMost = true;
                blockRegionSize = delimiter.getInnerDelimiterSize();
                upperLeftSource = delimiter.getInnerDelimiterUpperLeftLocation();
            }

            Recorder.blockRegionSize = blockRegionSize;
            delay = 1000 / frameRate;
            
            //Initialize buffers
            bitmapBuffer = new Bitmap(blockRegionSize.Width, blockRegionSize.Height);
            graphicsBuffer = Graphics.FromImage(bitmapBuffer);
            streamWriterThread = new Thread(streamWriter);
            stopWatch = new Stopwatch();
            frames = new List<Bitmap>();

            //Start countdown, when it is done it will start recording
            (new Countdown()).Show();
        }

        public void Start()
        {
            Settings instance = Settings.Instance;
            Start(instance.VideoFileFormat, 1, "./ola.gif");  
        }

        public void OnTimeoutEventHandler()
        {
            recording = true;
            streamWriterThread.Start(); 
            OnRecordStart?.Invoke();
        }
    }
}
