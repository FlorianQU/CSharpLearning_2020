using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeProject
{
    public class Triangle : Shape
    {
        public Point PointA { get; }
        public Point PointB { get; }
        public Point PointC { get; }
        public Triangle(Point pointA, Point pointB, Point pointC)
        {
            PointA = pointA;
            PointB = pointB;
            PointC = pointC;
        }
        public static bool TriangleIsValid(Point pointA, Point pointB, Point pointC)
        {
            return (pointB.X - pointA.X) * (pointC.Y - pointA.Y) != (pointB.Y - pointA.Y) * (pointC.X - pointA.X);
        }
        public override double GetPerimeter()
        {
            return PointA.GetDistance(PointB) + PointA.GetDistance(PointC) + PointB.GetDistance(PointC);
        }
        public override double GetArea()
        {
            double p = this.GetPerimeter() / 2.0;
            return Math.Sqrt(p * (p - PointA.GetDistance(PointB)) * (p - PointA.GetDistance(PointC)) * (p - PointB.GetDistance(PointC)));
        }
        public override double GetOverlapArea(Shape newShape)
        {
            if (newShape is Rectangle)
            {
                return Overlap.TriangleWithRectangle(this, newShape as Rectangle);
            }
            else if (newShape is Triangle)
            {
                return Overlap.TriangleWithTriangle(this, newShape as Triangle);
            }
            else if (newShape is Circle)
            {
                return Overlap.TriangleWithCircle(this, newShape as Circle);
            }
            else
            {
                return -1;
            }
        }
    }
}
