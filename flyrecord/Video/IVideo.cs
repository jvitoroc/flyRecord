using System.Drawing;

namespace flyrecord
{
    public interface IVideo
    {
        void WriteFrame(Image image, int delay = -1);
        void Finish();
    }
}
