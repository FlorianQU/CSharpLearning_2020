using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace StatusRecording
{
    class Program
    {
        static void Main(string[] args)
        {
            Entrance();
            while (true)
            {
                Console.WriteLine("Do you want to continue? Enter y to continue, n to quit.");
                string choice = Console.ReadLine();
                if (choice == "y")
                {
                    Entrance();
                }
                else if (choice == "n")
                {
                    return;
                }
            }
        }
        public static void Entrance()
        {
            Console.WriteLine("Which operation do you choose? Number 0,1,2,3 correspond to Insert/Delete/Update/Query.");
            Console.WriteLine("Please enter a corresponding number, then press enter.");
            string operationChoice = Console.ReadLine();
            int choice = -1;
            if (int.TryParse(operationChoice, out choice))
            {
                switch (choice)
                {
                    case 0:
                        Insert insert = new Insert();
                        insert.MainProcess();
                        break;
                    case 1:
                        Delete delete = new Delete();
                        delete.MainProcess();
                        break;
                    case 2:
                        Update update = new Update();
                        update.MainProcess();
                        break;
                    case 3:
                        Query query = new Query();
                        query.QueryOperation();
                        break;
                    default:
                        Console.WriteLine("Input is not among 0,1,2,3, please re-input.");
                        Entrance();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Input is not a number, please re-input.");
                Entrance();
            }
        }
    }
}
