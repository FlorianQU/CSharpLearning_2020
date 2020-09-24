using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeProject
{
    public class Rectangle : Shape
    {
        public Point LeftBottom { get; }
        public Point RightTop { get; }
        public Rectangle(Point leftBottom, Point rightTop)
        {
            LeftBottom = leftBottom;
            RightTop = rightTop;
        }
        public static bool RectangleIsValid(Point leftBottom, Point rightTop)
        {
            return leftBottom.X < rightTop.X && leftBottom.Y < rightTop.Y;
        }
        override public double GetPerimeter()
        {
            return 2 * ((RightTop.X - LeftBottom.X) + (RightTop.Y - LeftBottom.Y));
        }
        override public double GetArea()
        {
            return (RightTop.X - LeftBottom.X) * (RightTop.Y - LeftBottom.Y);
        }
        override public double GetOverlapArea(Shape newShape)
        {
            if (newShape is Rectangle)
            {
                return Overlap.RectangleWithRectangle(this, newShape as Rectangle);
            }
            else if (newShape is Triangle)
            {
                return Overlap.TriangleWithRectangle(newShape as Triangle, this);
            }
            else if (newShape is Circle)
            {
                return Overlap.CircleWithRectangle(newShape as Circle, this);
            }
            else
            {
                return -1;
            }
        }

    }
}
