using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DrawTrajectory
{
    class FileReader
    {
        private List<float> xRead = new List<float>();
        private List<float> yRead = new List<float>();
        private List<float> zRead = new List<float>();
        private string readPath;
        public FileReader(string inputPath)
        {
            readPath = inputPath;
        }
        public void LoadData()
        {
            using (FileStream fileStream = new FileStream(readPath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    string content = "";
                    string[] contentList;
                    while ((content = streamReader.ReadLine()) != null)
                    {
                        contentList = content.Split(',');
                        xRead.Add(Single.Parse(contentList[0]));
                        yRead.Add(Single.Parse(contentList[1]));
                        zRead.Add(Single.Parse(contentList[2]));
                    }
                }
            }
        }
        public List<float> GetXContent()
        {
            return xRead;
        }
        public List<float> GetYContent()
        {
            return yRead;
        }
        public List<float> GetZContent()
        {
            return zRead;
        }
    }
}