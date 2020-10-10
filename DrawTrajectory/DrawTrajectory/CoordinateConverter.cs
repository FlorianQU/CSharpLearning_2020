using System;
using System.Collections.Generic;
using System.Text;

namespace DrawTrajectory
{
    public class CoordinateConverter
    {
        public float XMin { get; set; }
        public float XMax { get; set; }
        public float YMin { get; set; }
        public float YMax { get; set; }
        public float XUnit { get; set; }
        public float YUnit { get; set; }
        public CoordinateConverter(float xMin, float xMax, float yMin, float yMax, float xUnit, float yUnit)
        {
            XMin = xMin;
            XMax = xMax;
            YMin = yMin;
            YMax = yMax;
            XUnit = xUnit;
            YUnit = yUnit;
        }
        public Coordinate ConvertToCoordinate(float x, float y)
        {
            int xCoord = Convert.ToInt16((x - XMin) / XUnit);
            int yCoord = Convert.ToInt16((y - YMin) / YUnit);
            return new Coordinate(xCoord, yCoord);
        }
        public int[] ReturnResolution()
        {
            int xResolution = Convert.ToInt16((XMax - XMin) / XUnit) + 1;
            int yResolution = Convert.ToInt16((YMax - YMin) / YUnit) + 1;
            return new int[] { xResolution, yResolution };
        }
    }
}
