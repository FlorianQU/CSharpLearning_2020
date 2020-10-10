using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OrganisedStatusRecording
{
    class RecordsReader
    {
        public string LoadData(Records records, string[] tableHead)
        {
            string readPath = "";
            Console.WriteLine("Please enter your file path for operation.");
            readPath = Console.ReadLine();
            while (!File.Exists(readPath))
            {
                Console.WriteLine("File does not exist, please check your file and reinput path.");
                readPath = Console.ReadLine();
            }
            using (FileStream fileStream = new FileStream(readPath, FileMode.Open))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    string stringRead = "";
                    stringRead = streamReader.ReadLine();
                    if (stringRead != null)
                    {
                        if (stringRead != String.Join(',', tableHead))
                        {
                            records.Add(new Record(stringRead.Split(',')));
                        }
                    }
                    while ((stringRead = streamReader.ReadLine()) != null)
                    {
                        records.Add(new Record(stringRead.Split(',')));
                    }
                }
            }
            return readPath;
        }
    }
}
