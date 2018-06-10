using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace flyrecord
{

    public class Frame
    {
        public int delay;
        public Bitmap buffer;

        public Frame(Bitmap buffer, int delay)
        {
            this.delay = delay;
            this.buffer = buffer;
        }

        public void Dispose()
        {
            buffer.Dispose();
            buffer = null;
            delay = 0;
        }
    }

    public enum RecorderStatus
    {
        Stopped,
        Preparing,
        Recording
    }

    public sealed class Recorder
    {

        private SaveFileDialog saveFileDialog;

        private static Size blockRegionSize;
        private static Point upperLeftSource;
        private readonly static Point upperLeftDestination = new Point(0, 0);
        private static int delay;
        private static Recorder instance = null;
        private static bool recording = false; 
        private static readonly object padlock = new object();

        private RecorderStatus RecorderStatus = RecorderStatus.Stopped;

        private static Thread streamWriterThread;

        private static Bitmap bitmapBuffer;
        private static Graphics graphicsBuffer;
        private static List<Frame> frames;
        private Countdown countdown = null; 

        private static Stopwatch stopWatch;

        private static int totalFrames;

        public delegate void OnRecordStartEventHandler();
        public delegate void OnRecordStopCompleteEventHandler();
        public delegate void OnPreparingEventHandler();
        public static event OnRecordStartEventHandler OnRecordStart;
        public static event OnRecordStopCompleteEventHandler OnRecordStopComplete;
        public static event OnPreparingEventHandler OnPreparing;

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

        public RecorderStatus Status
        {
            get
            {
                return RecorderStatus;
            }
        }

        //Capture user screen and write it to the buffer
        private static void streamWriter()
        {
            stopWatch.Start();
            Stopwatch internalStopwatch = new Stopwatch();
            while (recording) {
                internalStopwatch.Start();
                bitmapBuffer = new Bitmap(blockRegionSize.Width, blockRegionSize.Height);
                graphicsBuffer = Graphics.FromImage(bitmapBuffer);
                graphicsBuffer.CopyFromScreen(upperLeftSource, upperLeftDestination, blockRegionSize, CopyPixelOperation.SourceCopy);
                totalFrames += 1;
                internalStopwatch.Stop();
                frames.Add(new Frame(bitmapBuffer, (int)internalStopwatch.ElapsedMilliseconds));
                internalStopwatch.Reset();
                Thread.Sleep(delay);
            }
            stopWatch.Stop();
        }

        public void Stop() {
            if (RecorderStatus == RecorderStatus.Preparing)
            {
                if (countdown != null)
                {
                    countdown.Stop();
                    countdown.Close();
                    countdown = null;
                }
                Dispose();
                OnRecordStopComplete?.Invoke();
                return;
            }
            RecorderStatus = RecorderStatus.Stopped;
            recording = false;

            //Wait for the recording thread to end
            streamWriterThread.Join();

            int meanDelay = (int)stopWatch.ElapsedMilliseconds / totalFrames;

            saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = Path.GetFullPath(Settings.Instance.OutputPath);
            saveFileDialog.ShowDialog();

            GIF gif = new GIF(meanDelay, Path.Combine(Settings.Instance.OutputPath, saveFileDialog.FileName));
            gif.Save(frames);
            gif = null;

            Dispose();

            OnRecordStopComplete?.Invoke();

        }

        private void Dispose(){
            for(int i = 0; i < frames.Count; i++)
            {
                frames[i].Dispose();
                frames[i] = null;
            }
            frames = null;
            if (bitmapBuffer != null)
                bitmapBuffer.Dispose();
            stopWatch = null;
            if (graphicsBuffer != null)
                graphicsBuffer.Dispose();
            streamWriterThread = null;
            totalFrames = 0;
        }

        public void Start(float frameRate) {
            RecorderStatus = RecorderStatus.Preparing;
            OnPreparing?.Invoke();
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
            delay = (int)(1000.0 / frameRate);
            
            //Initialize buffers
            streamWriterThread = new Thread(streamWriter);
            stopWatch = new Stopwatch();
            frames = new List<Frame>();

            //Start countdown, when it is done it will start recording
            (countdown = new Countdown()).Show();
        }

        public void Start()
        {
            Start(60);  
        }

        public void OnTimeoutEventHandler()
        {
            recording = true;
            streamWriterThread.Start();
            RecorderStatus = RecorderStatus.Recording;
            OnRecordStart?.Invoke();
        }
    }
}
