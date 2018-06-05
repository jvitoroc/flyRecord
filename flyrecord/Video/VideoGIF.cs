using System.Drawing;
using AnimatedGif;

namespace flyrecord
{
    class VideoGIF : Video
    {
        private AnimatedGifCreator gif;

        public VideoGIF(int delay, string outputPath) : base(delay, outputPath)
        {
            gif = new AnimatedGif.AnimatedGifCreator(outputPath, delay);
        }

        public override void WriteFrame(Image image, int delay=-1)
        {
            gif.AddFrame(image, delay,GifQuality.Bit8);
        }

        public override void Finish()
        {
            gif.Dispose();
        }
    }
}
