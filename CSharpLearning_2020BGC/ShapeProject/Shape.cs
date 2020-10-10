using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeProject
{
    public abstract class Shape
    {
        abstract public double GetPerimeter();
        abstract public double GetArea();
        abstract public double GetOverlapArea(Shape newShape);
    }
}
