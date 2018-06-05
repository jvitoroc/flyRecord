using System.Drawing;
using AnimatedGif;

namespace flyrecord
{
    class VideoGIF : Video
    {
        private AnimatedGifCreator gif;

        public VideoGIF(int frameRate, string outputPath) : base(frameRate, outputPath)
        {
            gif = AnimatedGif.AnimatedGif.Create(outputPath, 100);
        }

        public override void WriteFrame(Image image)
        {
            gif.AddFrame(image, , GifQuality.Bit8);
        }

        public override void Finish()
        {
            gif.Dispose();
        }
    }
}
