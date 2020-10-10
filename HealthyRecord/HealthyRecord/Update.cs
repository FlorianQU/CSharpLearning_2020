using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyRecord
{
    class Update : Operation
    {
        public Update(Records records) : base(records) { }
        private Record newRecord;
        protected override void CustomizedOperation()
        {
            CheckGIN();
            int index = CheckIndex();
            CheckContent(index);
            records.Update(newRecord);
            Console.WriteLine("Successfully updated, new record as follows:");
            Console.WriteLine(string.Join(',', newRecord.ReturnContent()));
            #region
            //Console.WriteLine("Please enter the content that you replace with.");
            //if (records.Update(GIN, index, content))
            //{
            //    Console.WriteLine("Record replaced.");
            //}
            //else
            //{
            //    Console.WriteLine("Record not exists.");
            //}
            #endregion
        }
        private void CheckGIN()
        {
            Console.WriteLine("Please enter GIN that you want to update.");
            string GINString = Console.ReadLine();
            long GINNumber = -1;
            while (!long.TryParse(GINString, out GINNumber))
            {
                Console.WriteLine("Input is not a number, please try again.");
                GINString = Console.ReadLine();
            }
            Record queryRecord = records.Query(GINNumber);
            if (queryRecord != null)
            {
                newRecord = queryRecord;
            }
            else
            {
                Console.WriteLine("Record with input GIN not exists, please re-input.");
                CheckGIN();
            }
        }
        private int CheckIndex()
        {
            Console.WriteLine("Which element do you want to change? Please input a number from 1 to 4, " +
                                "corresponding to Name, Temperature, RiskArea and Symptom.");
            string updateChoice = Console.ReadLine();
            int choice = -1;
            while (!int.TryParse(updateChoice, out choice))
            {
                Console.WriteLine("Input is not a number, please re-input.");
                updateChoice = Console.ReadLine();
            }
            if (choice < 1 || choice > 4)
            {
                Console.WriteLine("Input is not among 1,2,3,4 please re-input.");
                return CheckIndex();
            }
            else
            {
                return choice;
            }
        }
        private void CheckContent(int index)
        {
            switch (index)
            {
                case 1:
                    newRecord.Name = InputName();
                    break;
                case 2:
                    newRecord.Temperature = InputTemperature();
                    break;
                case 3:
                    newRecord.RiskArea = InputRiskArea();
                    break;
                case 4:
                    newRecord.Symptom = InputSymptom();
                    break;
                default:
                    break;
            }
        }
    }
}
