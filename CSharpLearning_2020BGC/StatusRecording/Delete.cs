using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace StatusRecording
{
    public class Delete
    {
        string readPath = @"C:/CSharpLearning_Files/ConsoleApplication_SaveFile/save1.csv";
        DataTable dataTable = new DataTable();
        bool FileExist = true;
        public void MainProcess()
        {
            Tools.Initialize(readPath, dataTable, out bool FileExist);
            DeleteOperation();
        }
        public void DeleteOperation()
        {
            if (FileExist)
            {
                Console.WriteLine("File is loaded, please type the GIN that you want to delete, then press enter.");
                string GINToDelete = Console.ReadLine();
                string selectClause = "GIN = '" + GINToDelete + "'";
                DataRow[] searchResult = dataTable.Select(selectClause);
                if (searchResult.Length > 0)
                {
                    foreach (DataRow row in searchResult)
                    {
                        dataTable.Rows.Remove(row);
                    }
                    Tools.RegenerateFile(readPath, dataTable);
                    Console.WriteLine($"System has deleted desired data and recorded at {readPath}");

                }
                else
                {
                    Console.WriteLine("No datarow corresponds to your GIN, please check your GIN.");
                    return;
                }
            }
            else
            {
                return;
            }
            EndRequest();
        }

        private void EndRequest()
        {
            Console.WriteLine("Enter 'y' to delete other information, enter 'n' to return to main program.");
            string userChoice = Console.ReadLine();
            if (userChoice == "y")
            {
                DeleteOperation();
            }
            else if (userChoice == "n")
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid input, pleaese re-enter.");
                EndRequest();
            }
        }
    }
}
