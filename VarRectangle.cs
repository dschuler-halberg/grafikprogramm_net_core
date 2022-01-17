using ImageTools;
using SkiaSharp;

namespace Grafikprogramm
{
    class VarRectangle : IImage
    {

        private readonly SKColor ForegroundColor = SKColors.Red;

        private readonly SKColor BackgroundColor = SKColors.LightGreen;

        private Point TopLeft,TopRight,BottomLeft,BottomRight;

        

        public VarRectangle(SKColor foregroundColor, SKColor backgroundColor,
            int topLeftX, int topLeftY, int topRightX, int topRightY, int bottomLeftX, int bottomLeftY, int bottomRightX, int bottomRightY)
        {
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
            TopLeft = new Point(topLeftX, topLeftY);
            TopRight = new Point(topRightX, topRightY);
            BottomLeft = new Point(bottomLeftX, bottomLeftY);
            BottomRight = new Point(bottomRightX,bottomRightY);
        }

        public SKColor GetPixelColor(int x, int y)
        {
            Point p = new Point(x, y);
            if (IsRightToLine(BottomLeft, TopLeft, p)
                &&
                IsRightToLine(TopLeft, TopRight, p)
                &&
                IsRightToLine(TopRight, BottomRight, p)
                &&
                IsRightToLine(BottomRight, BottomLeft, p)
                )
            {
                return ForegroundColor;
            }
            return BackgroundColor;

        }

        public bool IsRightToLine(Point lstart, Point lend, Point x)
        {
            int v1X = lend.X - lstart.X;
            int v1Y = lend.Y - lstart.Y;

            int v2X = lend.X - x.X;
            int v2Y = lend.Y - x.Y;

            int res = (v1X * v2Y) - (v1Y * v2X);
            return res <= 0;
        }



        public int Height()
        {
            return 300;
        }

        public int Width()
        {
            return 400;
        }
    }
}