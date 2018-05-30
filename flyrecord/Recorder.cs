using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace flyrecord
{

    
    public sealed class Recorder
    {

        private static Video video;
        private static Size size;
        //private System.Windows.Forms.Timer timer;
        private static Recorder instance = null;
        private static bool recording = false;
        private static readonly object padlock = new object();
        private static Thread thread = new Thread(tick);

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

        public Recorder()
        {
            
        }

        public bool Recording()
        {
            return recording;
        }

        private static void tick(object delay)
        {
            Bitmap bm = new Bitmap(size.Width, size.Height);
            Graphics gp = Graphics.FromImage(bm);
            int _delay = (int)(delay);
            while (recording) {
                gp.CopyFromScreen(0, 0, 0, 0, size);
                video.writeFrame(bm);
                Thread.Sleep(_delay);
            }
            bm.Dispose();
            gp.Dispose();
        }

        public void stop() {
            if (recording == false)
            {
                throw new InvalidOperationException();
            }
            recording = false;

            thread.Join();
            //timer.Stop();
            //timer.Enabled = false;
            Dispose();
        }

        public void Dispose()
        {
            //timer.Dispose();
            video.Finish();
            video = null;
        }

        public void start(VideoFileFormat videoFileFormat, int frameRate, string outputPath, Size _size) {
            recording = true;
            size = _size;
            //timer = new System.Windows.Forms.Timer();
            //timer.Tick += new EventHandler(tick);
           // timer.Enabled = true;
            //timer.Start();
            video = Video.Create(videoFileFormat, frameRate, outputPath);
            //timer.Interval = 1000 / frameRate;
            int delay = 1000 / frameRate;
            thread.Start(delay);
        }
    }
}
