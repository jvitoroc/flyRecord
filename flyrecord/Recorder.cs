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

    public class Frame
    {
        public int delay;
        public Bitmap frameBuffer;
        
        public Frame(Bitmap frame, int delay)
        {
            this.delay = delay;
            this.frameBuffer = frame;
        }
    }

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

        private static Thread streamWriterThread;
        private static Thread streamReaderThread;

        private static Bitmap bitmapBuffer;
        private static Graphics graphicsBuffer;

        private static Stopwatch stopWatch;

        public delegate void OnRecordStartEventHandler();
        public delegate void OnRecordStopCompleteEventHandler();
        public static event OnRecordStartEventHandler OnRecordStart;
        public static event OnRecordStopCompleteEventHandler OnRecordStopComplete;

        private static ConcurrentQueue<Bitmap> queueStream;

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
            while (recording) {
                graphicsBuffer.CopyFromScreen(upperLeftSource, upperLeftDestination, blockRegionSize);
                queueStream.Enqueue(bitmapBuffer);
                Thread.Sleep(delay);
            }
        }

        private static void streamReader()
        {
            Bitmap localBuffer;
            while (recording)
            {
                if (queueStream.TryDequeue(out localBuffer))
                {
                    video.WriteFrame(localBuffer, (int)stopWatch.ElapsedMilliseconds+delay);
                    stopWatch.Reset();
                    stopWatch.Start();
                }
            }
        }

        public void Stop() {
     
            recording = false;
            //wait for the recording threads to end
            streamWriterThread.Join();
            streamReaderThread.Join();

            video.Finish();
            Dispose();
            OnRecordStopComplete?.Invoke();
        }

        private void Dispose()
        {
            video = null;
            queueStream = null;
            bitmapBuffer.Dispose();
            graphicsBuffer.Dispose();
            streamReaderThread = null;
            streamWriterThread = null;
        }

        public void Start(VideoFileFormat videoFileFormat, int frameRate, string outputPath) {
            Size blockRegionSize;

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
            video = Video.Create(videoFileFormat, delay, outputPath);
            

            //Initialize buffers
            bitmapBuffer = new Bitmap(blockRegionSize.Width, blockRegionSize.Height);
            graphicsBuffer = Graphics.FromImage(bitmapBuffer);
            queueStream = new ConcurrentQueue<Bitmap>();
            streamWriterThread = new Thread(streamWriter);
            streamReaderThread = new Thread(streamReader);
            stopWatch = new Stopwatch();

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
            streamReaderThread.Start();
            OnRecordStart?.Invoke();
        }
    }
}
