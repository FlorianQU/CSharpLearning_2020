using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HealthyRecord
{
    class Operation
    {
        protected Records records;
        public Operation(Records records)
        {
            this.records = records;
        }
        public void MainFunction()
        {
            CustomizedOperation();
            while (true)
            {
                Console.WriteLine("Enter 'y' to redo this operation, enter 'n' to return to main program.");
                string userChoice = Console.ReadLine();
                if (userChoice == "y")
                {
                    CustomizedOperation();
                }
                else if (userChoice == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, pleaese re-enter.");
                }
            }
        }
        protected virtual void CustomizedOperation() { }
        protected void PrintRecord(List<Record> recordList)
        {
            foreach (Record element in recordList)
            {
                Console.WriteLine(string.Join(',', element.ReturnContent()));
            }
        }
        protected string InputName()
        {
            Console.WriteLine("Please type in your name, then press enter.");
            string name = Console.ReadLine();
            while (name == "")
            {
                Console.WriteLine("Name can not be empty, please type your name.");
                name = Console.ReadLine();
            }
            return name;
        }
        protected float InputTemperature()
        {
            Console.WriteLine("Please type your temperature (numeric input only) then press Enter.");
            string temperatureString = Console.ReadLine();
            float temperature = 0;

            if (float.TryParse(temperatureString, out temperature))
            {
                return temperature;
            }
            else
            {
                Console.WriteLine("Input is not a number, please try again.");
                return InputTemperature();
            }
        }
        protected bool InputRiskArea()
        {
            Console.WriteLine("Is your community at high risk? Enter 'y'/'n' then press Enter.");
            string highRisk = Console.ReadLine();
            if (highRisk == "y")
            {
                return true;
            }
            else if (highRisk == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input, please try again.");
                return InputRiskArea();
            }
        }
        protected string InputSymptom()
        {
            Console.WriteLine("Do you have any suspicious symptoms?");
            Console.WriteLine("If yes, type your symptoms then press enter. Or just print enter to next step.");
            string symptoms = Console.ReadLine();
            if (symptoms == "")
            {
                symptoms = "No symptoms";
            }
            return symptoms;
        }

    }
}
