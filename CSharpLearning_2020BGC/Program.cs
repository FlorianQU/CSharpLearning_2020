using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace CSharpLearning_2020BGC
{
    class Program
    {
        //static public void CheckData(string path)
        //{
        //    StreamReader streamReader = new StreamReader(path);
        //    string stringRead = streamReader.ReadLine();
        //    for (int i = 0; stringRead != null; i++)
        //    {
        //        string[] stringListRead = stringRead.Split(',');
        //        foreach (string stringElement in stringListRead)
        //        {
        //            Console.WriteLine(stringElement);
        //        }
        //        stringRead = streamReader.ReadLine();
        //        Console.WriteLine();
        //    }
        //    streamReader.Close();
        //}
        //static void Main(string[] args)
        //{
        //    CheckData("C:/CSharpLearning_Files/test1.csv");
        //}
        //public class testClass
        //{

        //}
        static void Main(string[] args)
        {
            BaseClass bc = new BaseClass();
            DerivedClass dc = new DerivedClass();
            bc.MainProcess();
            dc.MainProcess();
        }




    }
    public class BaseClass
    {
        public string baseField = "Base Field";
        public void BaseMethod()
        {
            Console.WriteLine("Base Method.");
        }
        public void MainProcess()
        {
            Console.WriteLine("Hidden method triggered.");
            BaseMethod();
        }
    }
    public class DerivedClass: BaseClass
    {
        new public string baseField = "Derived Field";
        new public void BaseMethod()
        {
            Console.WriteLine("Derived Method.");
        }
    }


}
