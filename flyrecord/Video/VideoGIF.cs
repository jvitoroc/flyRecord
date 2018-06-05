using System.Drawing;
using ImageMagick;

namespace flyrecord
{
    class VideoGIF : Video
    {
        MagickImageCollection collection = new MagickImageCollection();
        private int currentFrame = 0;

        public VideoGIF(int delay, string outputPath) : base(delay, outputPath)
        {
        }

        public override void WriteFrame(Bitmap image)
        {
            collection.Add(new MagickImage(image));
            collection[currentFrame].AnimationDelay = 16;
            currentFrame += 1;
        }

        public override void Finish()
        {
            collection.Optimize();
            collection.Write(outputPath);
        }
    }
}
