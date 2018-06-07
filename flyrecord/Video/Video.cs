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

        public Video()
        {
        }

        public virtual void WriteFrame(Image image, int delay = -1) {  }
        public virtual void Finish() { }
        public virtual void SaveStream(List<Bitmap> list, int delay, string filePath) { }

        public static Video Create(VideoFileFormat videoFileFormat)
        {
                return new VideoGIF();
            throw new ArgumentException();
        }
    }
}
