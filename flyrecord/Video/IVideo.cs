using System.Drawing;

namespace flyrecord
{
    public interface IVideo
    {
        void WriteFrame(Image image);
        void Finish();
    }
}
