using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq.Expressions;
using System.Data;
using System.Security;

namespace StatusRecording
{
    public class Insert
    {
        string[] tableHead = new string[] { "GIN", "RecordDate", "Temperature", "Community at Risk", "Symptoms" };
        string savePath = @"C:/CSharpLearning_Files/ConsoleApplication_SaveFile/save1.csv";
        DataTable dataTable = new DataTable();
        int currentIndex = 0;
        public void MainProcess()
        {
            Initialize();
            InsertOperation();
        }
        public void Initialize()
        {
            GenerateColumns(dataTable, tableHead);
            if (!File.Exists(savePath))
            {
                //File.Create(savePath).Close();
                //using (File.Create(savePath))
                using (FileStream fileStream = new FileStream(savePath, FileMode.Create))
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
                    }
                }
                Console.WriteLine($"Creating new .csv file at {savePath}.");
            }
        }
        public void InsertOperation()
        {
            this.currentIndex = 0;
            string dataRow = "";
            DataRow row = dataTable.NewRow();
            row = InputGIN(row, ref currentIndex);
            row = InputDate(row, ref currentIndex);
            row = InputTemperature(row, ref currentIndex);
            row = InputRiskArea(row, ref currentIndex);
            row = InputSymptom(row, ref currentIndex);
            
            using (FileStream fileStream = new FileStream(savePath, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    foreach (string element in tableHead)
                    {
                        dataRow += row[element];
                        dataRow += ",";
                    }
                    dataRow = dataRow.Substring(0, dataRow.Length - 1);
                    streamWriter.WriteLine(dataRow);
                }
            }
            dataTable.Rows.Add(row);
            EndRequest();
        }
        private DataRow InputGIN(DataRow row, ref int index)
        {
            Console.WriteLine("Please type your GIN (numeric input only) then press Enter.");
            string GIN = Console.ReadLine();
            int GIN_number = 0;
            if (int.TryParse(GIN, out GIN_number))
            {
                row["GIN"] = GIN;
                PrintInformation(row, index);
                index += 1;
                return row;
            }
            else
            {
                Console.WriteLine("Input is not a number, please try again.");
                return InputGIN(row, ref index);
            }
        }
        private DataRow InputDate(DataRow row, ref int index)
        {
            Console.WriteLine("Using local time to record your information.");
            string date = DateTime.Now.ToString();
            Console.WriteLine($"Record time is {date}");
            row["RecordDate"] = date;
            index += 1;
            return row;
        }
        private DataRow InputTemperature(DataRow row, ref int index)
        {
            Console.WriteLine("Please type your temperature (numeric input only) then press Enter.");
            string temperature_str = Console.ReadLine();
            float temperature = 0;
            if (float.TryParse(temperature_str, out temperature))
            {
                if (temperature < 36.0 || temperature > 37.3)
                {
                    Console.WriteLine("Abnormal temperature, please contact a doctor.");
                }
                row["Temperature"] = (temperature_str + " celsius");
                PrintInformation(row, index);
                index += 1;
                return row;
            }
            else
            {
                Console.WriteLine("Input is not a number, please try again.");
                return InputTemperature(row, ref index);
            }
        }
        private DataRow InputRiskArea(DataRow row, ref int index)
        {
            Console.WriteLine("Is your community at high risk? Enter 'y'/'n' then press Enter.");
            string highRisk = Console.ReadLine();
            if (highRisk == "y" || highRisk == "n")
            {
                row["Community at Risk"] = highRisk == "y" ? "Yes" : "No";
                PrintInformation(row, index);
                index += 1;
                return row;
            }
            else
            {
                Console.WriteLine("Invalid input, please try again.");
                return InputRiskArea(row, ref index);
            }
        }
        private DataRow InputSymptom(DataRow row, ref int index)
        {
            Console.WriteLine("Do you have any suspicious symptoms?");
            Console.WriteLine("If yes, type your symptoms then press enter. Or just print enter to next step.");
            string symptoms = Console.ReadLine();
            if (symptoms == "")
            {
                symptoms = "No symptoms";
            }
            row["Symptoms"] = symptoms;
            PrintInformation(row, index);
            index += 1;
            return row;
        }
        private void EndRequest()
        {
            Console.WriteLine($"Information recorded at {savePath}.");
            Console.WriteLine("Enter 'y' to enter new information, enter 'n' to return to main program.");
            string userChoice = Console.ReadLine();
            if (userChoice == "y")
            {
                InsertOperation();
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
        private void PrintInformation(DataRow row, int index)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("#################################");
            Console.WriteLine($"Current input data is: ");
            for (int i = 0; i <= index; i++)
            {
                Console.WriteLine($"{tableHead[i]}:  {row[tableHead[i]]}");
            }
            Console.WriteLine("#################################");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void GenerateColumns(DataTable dataTable, string[] tableHead)
        {
            foreach (string head in tableHead)
            {
                DataColumn datacolumn = new DataColumn();
                datacolumn.ColumnName = head;
                datacolumn.DataType = typeof(String);
                dataTable.Columns.Add(datacolumn);
            }
        }
    }

}
