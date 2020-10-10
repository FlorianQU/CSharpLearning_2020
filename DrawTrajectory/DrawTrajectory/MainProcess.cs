using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text;

namespace DrawTrajectory
{
    class MainProcess
    {
        static int i = 8;
        private string readPath = @$"C:/CSharpLearning_Files/Trajectory_Data/Trajectory_Data/well-{i}.csv";
        private string xyWritePath = @$"C:/CSharpLearning_Files/Trajectory_Data/OutputFile/well-{i}_xy.txt";
        private string xzWritePath = @$"C:/CSharpLearning_Files/Trajectory_Data/OutputFile/well-{i}_xz.txt";
        private string yzWritePath = @$"C:/CSharpLearning_Files/Trajectory_Data/OutputFile/well-{i}_yz.txt";

        private float xUnit = 5;
        private float yUnit = 5;
        private float zUnit = 10;
        public void Start()
        {
            FileReader fileReader = new FileReader(readPath);
            fileReader.LoadData();
            List<float> xData = fileReader.GetXContent();
            List<float> yData = fileReader.GetYContent();
            List<float> zData = fileReader.GetZContent();
            for (int i = 0; i < zData.Count; i++)
            {
                zData[i] *= -1;
            }
            DrawAndOutput(xData, yData, xyWritePath, xUnit, yUnit);
            DrawAndOutput(xData, zData, xzWritePath, xUnit, zUnit);
            DrawAndOutput(yData, zData, yzWritePath, yUnit, zUnit);


        }
        private void DrawAndOutput(List<float> xContent, List<float> yContent, string writePath, float xUnit, float yUnit)
        {
            float xMin = xContent.Min();
            float xMax = xContent.Max();
            float yMin = yContent.Min();
            float yMax = yContent.Max();
            CoordinateConverter coordinateConverter = new CoordinateConverter(xMin, xMax, yMin, yMax, xUnit, yUnit);
            int[] resolution = coordinateConverter.ReturnResolution();
            TrajectoryDrawer trajectoryDrawer = new TrajectoryDrawer(resolution[0], resolution[1]);
            Coordinate currentCoordinate = coordinateConverter.ConvertToCoordinate(xContent[0], yContent[0]);
            trajectoryDrawer.InitialPoint(currentCoordinate);
            for (int i = 1; i < xContent.Count; i++)
            {
                Coordinate newCoordinate = coordinateConverter.ConvertToCoordinate(xContent[i], yContent[i]);
                trajectoryDrawer.AddPoint(currentCoordinate, newCoordinate);
                currentCoordinate = newCoordinate;
            }
            string[,] outputMap = trajectoryDrawer.GetOutputArray();
            FileWriter fileWriter = new FileWriter(outputMap, writePath);
            fileWriter.WriteFile();
        }
    }
}
