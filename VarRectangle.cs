using Grafikprogramm;
using ImageTools;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace grafikprogramm_net_core
{
    public class VarRectangle : IImage
    {

        private readonly SKColor ForegroundColor = SKColors.Red;

        private readonly SKColor BackgroundColor = SKColors.LightGreen;

        private Point TopLeft;

        private Point TopRight;

        private Point BottomRight;

        private Point BottomLeft;

        public VarRectangle(SKColor foregroundColor, SKColor backgroundColor,
            int topLeftX, int topLeftY, int width, int height)
        {
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
            TopLeft = new Point(topLeftX, topLeftY);
            TopRight = new Point(topLeftX + width, topLeftY + height);
            BottomLeft = new Point(topLeftX, topLeftY + height);
            BottomRight = new Point(topLeftX + width, topLeftY + height);
        }

        public SKColor GetPixelColor(int x, int y)
        {
            if (x >= TopLeft.X && y >= TopLeft.Y &&
               x <= BottomRight.X && y <= BottomRight.Y)
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
