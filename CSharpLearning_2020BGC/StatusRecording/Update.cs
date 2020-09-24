using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;


namespace StatusRecording
{
    public class Update
    {
        string readPath = @"C:/CSharpLearning_Files/ConsoleApplication_SaveFile/save1.csv";
        DataTable dataTable = new DataTable();
        bool FileExist = true;
        public void MainProcess()
        {
            Tools.Initialize(readPath, dataTable, out bool FileExist);
            UpdateOperation();
        }
        public void UpdateOperation()
        {
            if (FileExist)
            {
                Console.WriteLine("File is loaded, please type the GIN that you want to update, then press enter.");
                string GINToUpdate = Console.ReadLine();
                string selectClause = "GIN = '" + GINToUpdate + "'";
                DataRow[] searchResult = dataTable.Select(selectClause);
                if (searchResult.Length > 0)
                {
                    Console.WriteLine("Please specify the item that you want to update.");
                    Console.WriteLine($"Please enter a number between 0 and {dataTable.Columns.Count - 1}, which corresponds to:");
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        Console.WriteLine($"{dataTable.Columns[i].ColumnName.ToString()}");
                    }
                    string choiceString = Console.ReadLine();
                    int choice = -1;
                    if (int.TryParse(choiceString, out choice))
                    {
                        Console.WriteLine("Please type your replacing content.");
                        string replaceContent = Console.ReadLine();
                        foreach (DataRow row in searchResult)
                        {
                            row[choice] = replaceContent;
                        }
                    }
                    Tools.RegenerateFile(readPath, dataTable);
                    Console.WriteLine($"System has updated desired data and recorded at {readPath}");

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
            Console.WriteLine("Enter 'y' to update other information, enter 'n' to return to main program.");
            string userChoice = Console.ReadLine();
            if (userChoice == "y")
            {
                UpdateOperation();
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
