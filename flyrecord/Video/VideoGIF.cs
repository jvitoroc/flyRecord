using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using AnimatedGif; 

namespace flyrecord
{
    class VideoGIF : Video
    {
        private AnimatedGifCreator gif;

        public VideoGIF(int delay, string outputPath) : base(delay, outputPath)
        {
            
        }

        public VideoGIF()
        {

        }

        public override void WriteFrame(Image image, int delay=-1)
        {
            if(gif == null)
                gif = new AnimatedGif.AnimatedGifCreator(outputPath, delay);
            gif.AddFrame(image, delay,GifQuality.Bit8);
        }

        public override void SaveStream(List<Bitmap> list, int delay, string filePath)
        {
            using(var gifCreator = new AnimatedGif.AnimatedGifCreator(filePath, delay))
            {
                for(int i = 0; i < list.Count; i++)
                {
                    gifCreator.AddFrame((Image)list[i]);
                    
                }
            }
        }

        public override void Finish()
        {
            gif.Dispose();
        }
    }
}
