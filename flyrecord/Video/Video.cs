using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flyrecord
{
    public abstract class Video : IVideo
    {
        protected string outputPath;
        protected int delay;

        public Video(int delay, string outputPath) {
            this.outputPath = outputPath;
            this.delay = delay;
        }

        public virtual void WriteFrame(Image image) {  }
        public virtual void WriteFrame(Bitmap image) { }
        public virtual void Finish() { }

        public static Video Create(VideoFileFormat videoFileFormat, int delay, string outputPath)
        {
                return new VideoGIF(delay, outputPath);
            throw new ArgumentException();
        }
    }
}
