using System;
using System.Collections.Generic;

using System.Text;
using ImageTools;
using SkiaSharp;

namespace Grafikprogramm
{
    public class VarRect : IImage
    {
        public readonly SKColor ForegroundColor = SKColors.Red;
        
        public readonly SKColor BackgroundColor = SKColors.LightGreen;
        
        public Point A, B, C, D;

        public VarRect(SKColor foregroundColor, SKColor backgroundColor, Point a, Point b, Point c, Point d)
        {
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
            A = a;
            B = b;
            C = c;
            D = d;
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

        public SKColor GetPixelColor(int x, int y)
        {
            Point p = new Point(x, y);
            if (IsRightToLine(A, B, p)
                &&
                IsRightToLine(B, C, p)
                &&
                IsRightToLine(C, D, p)
                &&
                IsRightToLine(D, A, p)
                )
            {
                return ForegroundColor;
            }
            return BackgroundColor;

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
