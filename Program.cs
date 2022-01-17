using System;
using ImageTools;
using SkiaSharp;

namespace Grafikprogramm
{
  class Program
  {

    public static int DefaultHeight = 400;

    public static int DefaultWidth = 300;

    static void Main(string[] args)
    {
      SimpleImage();
      //RandomImage();
    }
    

    private static void SimpleImage()
    {
      Canvas canvas = new Canvas(DefaultHeight, DefaultWidth);
      Circle circle1 = new Circle(new SKColor(255, 0, 219),
          SKColors.Transparent,
          50, 100,
          15);
      Rectangle rectangle1 = new Rectangle(
          SKColors.Chocolate,
          SKColors.Transparent,
          30, 40,
          25, 30);
      Triangle triangle1 = new Triangle(
          SKColors.LightGray,
          SKColors.Transparent,
          new Point(20, 50),
          new Point(200, 250),
          new Point(20, 200)
      );
      VarRect r1 = new VarRect(SKColors.Red, SKColors.Transparent, 10, 10, 100, 10, 100, 200, 10, 200);
      //canvas.AddShape(circle1);
      //canvas.AddShape(triangle1);
      //canvas.AddShape(rectangle1);
      canvas.AddShape(r1);
      string imagePath = "simple_image.png";
      ImageUtil.SavePNG(canvas, imagePath);
      ImageUtil.DisplayImage(imagePath);
    }

    private static void RandomImage()
    {
      int imageHeight = 1080;
      int imageWidth = 720;
      Random r = new Random();
      Canvas canvas = new Canvas(imageHeight, imageWidth);
      for (int i = 0; i < 50; i++)
      {
        int shapeType = r.Next(3);
        IImage shape;
        if (shapeType == 0)
        {
          shape = new Triangle(
             GetRandomColor(),
             SKColors.Transparent,
             new Point(r.Next(imageHeight), r.Next(imageWidth)),
             new Point(r.Next(imageHeight), r.Next(imageWidth)),
             new Point(r.Next(imageHeight), r.Next(imageWidth))
          );
        }
        else if (shapeType == 1)
        {
          shape = new Circle(
              GetRandomColor(),
              SKColors.Transparent,
              r.Next(imageHeight), r.Next(imageWidth),
              r.Next(100)
          );
        }
        else
        {
          shape = new Rectangle(
              GetRandomColor(),
              SKColors.Transparent,
              r.Next(imageHeight), r.Next(imageWidth),
              r.Next(imageHeight), r.Next(imageWidth)
          );

        }
        canvas.AddShape(shape);
      }
      string imagePath = "random_image.png";
      ImageUtil.SavePNG(canvas, imagePath);
      ImageUtil.DisplayImage(imagePath);
    }

    private static Random r = new Random();

    private static SKColor GetRandomColor()
    {
      return new SKColor((byte)r.Next(256), (byte)r.Next(256), (byte)r.Next(256));
    }
  }
}
