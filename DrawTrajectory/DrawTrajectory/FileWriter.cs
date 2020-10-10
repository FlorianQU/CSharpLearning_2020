using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DrawTrajectory
{
    class FileWriter
    {
        private string[,] trajectoryMap;
        private string writePath;
        public FileWriter(string[,] inputMap, string inputPath)
        {
            trajectoryMap = inputMap;
            writePath = inputPath;
        }
        public void WriteFile()
        {
            using (FileStream fileStream = new FileStream(writePath, FileMode.CreateNew, FileAccess.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream,Encoding.UTF8))
                {
                    for (int i = trajectoryMap.GetLength(0) - 1; i >= 0; i--)
                    {
                        //string output = "";
                        for (int j = 0; j < trajectoryMap.GetLength(1); j++)
                        {
                            if (trajectoryMap[i, j] != null)
                            {
                                streamWriter.Write(trajectoryMap[i, j]);
                            }
                            else
                            {
                                streamWriter.Write(" ");
                            }
                        }
                        streamWriter.Write('\n');
                    }
                }
            }
        }
    }
}
