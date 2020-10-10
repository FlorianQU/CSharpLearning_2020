using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeProject
{
    static public class Overlap
    {
        public static double TriangleWithCircle(Triangle triangle, Circle circle)
        {
            return 0;
        }
        public static double TriangleWithRectangle(Triangle triangle, Rectangle rectangle)
        {
            return 0;
        }
        public static double CircleWithRectangle(Circle circle, Rectangle rectangle)
        {
            return 0;
        }
        public static double TriangleWithTriangle(Triangle triangle1, Triangle triangle2)
        {
            return 0;
        }
        public static double CircleWithCircle(Circle circle1, Circle circle2)
        {
            return 0;
        }
        public static double RectangleWithRectangle(Rectangle rectangle1, Rectangle rectangle2)
        {
            Point leftBottom1 = rectangle1.LeftBottom;
            Point leftBottom2 = rectangle2.LeftBottom;
            Point rightTop1 = rectangle1.RightTop;
            Point rightTop2 = rectangle2.RightTop;
            if (leftBottom1.X >= rightTop2.X || leftBottom1.Y >= rightTop2.Y || leftBottom2.X >= rightTop1.X || leftBottom2.Y >= rightTop1.Y)
            {
                Console.WriteLine("Two shapes are not overlapped.");
                return 0;
            }
            else
            {
                double[] XArray = new double[] { leftBottom1.X, rightTop1.X, leftBottom2.X, rightTop2.X };
                double[] YArray = new double[] { leftBottom1.Y, rightTop1.Y, leftBottom2.Y, rightTop2.Y };
                Array.Sort(XArray);
                Array.Sort(YArray);
                return ((XArray[2] - XArray[1]) * (YArray[2] - YArray[1]));
            }
        }
    }
}
