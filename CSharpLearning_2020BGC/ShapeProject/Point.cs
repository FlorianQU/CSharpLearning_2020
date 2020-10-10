using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeProject
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double GetDistance(Point newPoint)
        {
            return Math.Sqrt((newPoint.X - this.X) * (newPoint.X - this.X) + (newPoint.Y - this.Y) * (newPoint.Y - this.Y));
        }
    }
}
