using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flyrecord
{
    public static class DelimiterSettings
    {
        private static Size _size;
        private static Point _position;

        public static void setSize(Size size)
        {
            _size = size;
        }

        public static void setSize(int width, int height)
        {
            _size = new Size(width, height);
        }

        public static void setPosition(Point position)
        {
            _position = position;
        }

        public static void setPosition(int x, int y)
        {
            _position = new Point(x, y);
        }

        public static Size getSize()
        {
            return _size;  
        }

        public static Point getPosition()
        {
            return _position;
        }

    }
}
