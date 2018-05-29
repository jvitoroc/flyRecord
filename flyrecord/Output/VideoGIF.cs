using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimatedGif;

namespace flyrecord
{
    class VideoGIF : Video
    {
        private AnimatedGifCreator gif;

        public VideoGIF(int frameRate, string outputPath) : base(frameRate, outputPath)
        {
            gif = AnimatedGif.AnimatedGif.Create(outputPath, 1 / frameRate);
        }

        public override void writeFrame(Image image)
        {
            gif.AddFrame(image);
        }

        public override void Finish()
        {
            gif.Dispose();
        }
    }
}
