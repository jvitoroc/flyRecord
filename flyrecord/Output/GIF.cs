using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using AnimatedGif; 

namespace flyrecord
{
    class GIF
    {
        private int meanDelay;
        private string outputPath;

        public GIF(int meanDelay, string outputPath)
        {
            this.meanDelay = meanDelay;
            this.outputPath = outputPath;
        }

        public void Save(List<Frame> frames)
        {
            using(var gifCreator = new AnimatedGif.AnimatedGifCreator(outputPath, meanDelay))
            {
                for(int i = 0; i < frames.Count; i++)
                {
                    Frame currFrame = frames[i];
                    gifCreator.AddFrame((Image)currFrame.buffer, currFrame.delay > meanDelay ? currFrame.delay: -1);

                }
            }
        }
    }
}
