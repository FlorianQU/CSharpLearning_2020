using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OrganisedStatusRecording
{
    class MainProcess
    {
        private string[] tableHead = new string[] { "GIN", "Name", "Temperature", "RiskArea", "Symptom" };
        private Records records = new Records();
        private string readPath = "";
        public void Launch()
        {
            RecordsReader recordsReader = new RecordsReader();
            readPath = recordsReader.LoadData(records, tableHead);
            Entrance();
            RecordsWriter recordsWriter = new RecordsWriter();
            recordsWriter.WriteData(records, readPath, tableHead);
        }
        private void Entrance()
        {
            Console.WriteLine("Which operation do you choose? Number 0,1,2,3 correspond to Insert/Delete/Update/Query.");
            Console.WriteLine("Please enter a corresponding number, then press enter.");
            string operationChoice = Console.ReadLine();
            int choice = -1;
            while (!int.TryParse(operationChoice, out choice))
            {
                Console.WriteLine("Input is not a number, please re-input.");
                operationChoice = Console.ReadLine();
            }
            switch (choice)
            {
                case 0:
                    Insert insert = new Insert(records);
                    insert.MainFunction();
                    break;
                case 1:
                    Delete delete = new Delete(records);
                    delete.MainFunction();
                    break;
                case 2:
                    Update update = new Update(records);
                    update.MainFunction();
                    break;
                case 3:
                    Query query = new Query(records);
                    query.MainFunction();
                    break;
                default:
                    Console.WriteLine("Input is not among 0,1,2,3, please re-input.");
                    Entrance();
                    break;
            }
            while (true)
            {
                Console.WriteLine("Do you want to continue? Enter y to continue, n to quit.");
                string endChoice = Console.ReadLine();
                if (endChoice == "y")
                {
                    Entrance();
                    break;
                }
                else if (endChoice == "n")
                {
                    break;
                }
            }
        }



    }
}
