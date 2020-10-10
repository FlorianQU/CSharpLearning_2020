using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace DrawTrajectory
{
    public class TrajectoryDrawer
    {
        public int XResolution { get; set; }
        public int YResolution { get; set; }
        private string[,] trajectoryMap;
        const string vertical = "|";
        const string dash = "-";
        const string slash = "/";
        const string backslash = "\\";
        const string plus = "+";
        private int numberOfHorizontal = 0;
        private int numberOfVertical = 0;
        private int numberOfSlash = 0;
        private int numberOfBackSlash = 0;
        private int xStep = 0;
        private int yStep = 0;

        public TrajectoryDrawer(int xResolution, int yResolution)
        {
            XResolution = xResolution;
            YResolution = yResolution;
            trajectoryMap = new string[YResolution, XResolution];
        }
        public void InitialPoint(Coordinate coordinate)
        {
            fillContent(coordinate.XCoord, coordinate.YCoord, plus);
        }
        public void AddPoint(Coordinate coordinate1, Coordinate coordinate2)
        {
            int xCurrent = coordinate1.XCoord;
            int yCurrent = coordinate1.YCoord;
            numberOfHorizontal = 0;
            numberOfVertical = 0;
            numberOfSlash = 0;
            numberOfBackSlash = 0;
            int xDistance = coordinate2.XCoord - coordinate1.XCoord;
            int yDistance = coordinate2.YCoord - coordinate1.YCoord;
            CheckNumberOfContent(Math.Abs(xDistance), Math.Abs(yDistance), Math.Sign(xDistance), Math.Sign(yDistance));
            for (int i = 0; i < numberOfSlash; i++)
            {
                xCurrent += xStep;
                yCurrent += yStep;
                fillContent(xCurrent, yCurrent, slash);
            }
            for (int i = 0; i < numberOfBackSlash; i++)
            {
                xCurrent += xStep;
                yCurrent += yStep;
                fillContent(xCurrent, yCurrent, backslash);
            }
            for (int i = 0; i < numberOfHorizontal; i++)
            {
                if ((i == 0) && ((numberOfSlash + numberOfBackSlash) != 0))
                {
                    yCurrent += yStep;
                }
                xCurrent += xStep;
                fillContent(xCurrent, yCurrent, dash);
            }
            for (int i = 0; i < numberOfVertical; i++)
            {
                if ((i == 0) && ((numberOfSlash + numberOfBackSlash) != 0))
                {
                    xCurrent += xStep;
                }
                yCurrent += yStep;
                fillContent(xCurrent, yCurrent, vertical);
            }
            fillContent(coordinate2.XCoord, coordinate2.YCoord, plus);
        }
        public string[,] GetOutputArray()
        {
            return trajectoryMap;
        }
        private void CheckNumberOfContent(int xAbs, int yAbs, int xSign, int ySign)
        {
            if (xAbs < 2)
            {
                if (yAbs >= 2)
                {
                    yStep = ySign;
                    numberOfVertical = yAbs - 1;
                }
            }
            else
            {
                xStep = xSign;
                if (yAbs < 2)
                {
                    numberOfHorizontal = xAbs - 1;
                }
                else
                {
                    yStep = ySign;
                    int difference = xAbs - yAbs;
                    if (difference > 0)
                    {
                        numberOfHorizontal = difference;
                    }
                    else
                    {
                        numberOfVertical = -difference;
                    }
                    int slashOrBackslash = Math.Min(xAbs, yAbs) - 1;
                    if (xSign * ySign > 0)
                    {
                        numberOfSlash = slashOrBackslash;
                    }
                    else
                    {
                        numberOfBackSlash = slashOrBackslash;
                    }
                }
            }
        }
        private void fillContent(int xCoord, int yCoord, string content)
        {
            if (content == plus || trajectoryMap[yCoord, xCoord] == null)
            {
                trajectoryMap[yCoord, xCoord] = content;
            }
        }

    }
}
