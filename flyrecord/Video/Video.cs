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
            this.delay = delay;
            this.outputPath = outputPath;
        }

        public virtual void WriteFrame(Image image, int delay = -1) {  }
        public virtual void Finish() { }

        public static Video Create(VideoFileFormat videoFileFormat, int frameRate, string outputPath)
        {
                return new VideoGIF(frameRate, outputPath);
            throw new ArgumentException();
        }
    }
}
