using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeProject
{
    public class Circle : Shape
    {
        public double Radius { get; }
        public Point Center { get; }
        public Circle(double radius, Point center)
        {
            Radius = radius;
            Center = center;
        }
        public static bool CircleIsValid(double radius, Point center)
        {
            return radius > 0;
        }
        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
        public override double GetOverlapArea(Shape newShape)
        {
            if (newShape is Rectangle)
            {
                return Overlap.CircleWithRectangle(this, newShape as Rectangle);
            }
            else if (newShape is Triangle)
            {
                return Overlap.TriangleWithCircle(newShape as Triangle, this);
            }
            else if (newShape is Circle)
            {
                return Overlap.CircleWithCircle(this, newShape as Circle);
            }
            else
            {
                return -1;
            }
        }
    }
}
