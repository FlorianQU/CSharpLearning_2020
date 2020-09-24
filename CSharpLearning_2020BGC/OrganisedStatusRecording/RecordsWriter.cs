using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OrganisedStatusRecording
{
    class RecordsWriter
    {
        public void WriteData(Records records, string writePath, string[] tableHead)
        {
            using (FileStream fileStream = new FileStream(writePath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine(String.Join(",", tableHead));
                    List<string[]> recordsContent = records.ReturnContents();
                    foreach (string[] element in recordsContent)
                    {
                        streamWriter.WriteLine(String.Join(",", element));
                    }
                }
            }
        }
    }
}
