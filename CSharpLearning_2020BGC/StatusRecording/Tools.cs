using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace StatusRecording
{
    static class Tools
    {
        public static void Initialize(string readPath, DataTable dataTable, out bool FileExist)
        {
            FileExist = true;
            if (!File.Exists(readPath))
            {
                Console.WriteLine($"File does not exist in provided path: {readPath}, please check your file.");
                FileExist = false;
            }
            else
            {
                using (FileStream fileStream = new FileStream(readPath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        string stringRead = "";
                        bool FirstLine = true;
                        while ((stringRead = streamReader.ReadLine()) != null)
                        {
                            string[] stringArray = stringRead.Split(',');
                            if (FirstLine)
                            {
                                for (int i = 0; i < stringArray.Length; i++)
                                {
                                    DataColumn column = new DataColumn();
                                    column.ColumnName = stringArray[i];
                                    column.DataType = typeof(String);
                                    dataTable.Columns.Add(column);
                                }
                                FirstLine = false;
                            }
                            else
                            {
                                DataRow row = dataTable.NewRow();
                                for (int i = 0; i < stringArray.Length; i++)
                                {
                                    row[i] = stringArray[i];
                                }
                                dataTable.Rows.Add(row);
                            }
                        }
                    }
                }
            }
        }
        public static void RegenerateFile(string readPath, DataTable dataTable)
        {
            using (FileStream fileStream = new FileStream(readPath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    string heads = "";
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        heads += dataTable.Columns[i].ColumnName.ToString();
                        if (i < dataTable.Columns.Count - 1)
                        {
                            heads += ",";
                        }
                    }
                    streamWriter.WriteLine(heads);

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        string dataRow = "";
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            dataRow += dataTable.Rows[i][j].ToString();
                            if (j < dataTable.Columns.Count - 1)
                            {
                                dataRow += ",";
                            }
                        }
                        streamWriter.WriteLine(dataRow);
                    }
                }
            }
        }
    }

}
