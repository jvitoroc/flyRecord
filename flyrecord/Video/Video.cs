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
        private string outputPath;
        private int frameRate;

        public Video(int frameRate, string outputPath) {
            this.frameRate = frameRate;
            this.outputPath = outputPath;
        }

        public virtual void WriteFrame(Image image) {  }
        public virtual void Finish() { }

        public static Video Create(VideoFileFormat videoFileFormat, int frameRate, string outputPath)
        {
                return new VideoGIF(frameRate, outputPath);
            throw new ArgumentException();
        }
    }
}
