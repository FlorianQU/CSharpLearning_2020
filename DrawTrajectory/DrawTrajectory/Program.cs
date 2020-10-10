using System;

namespace DrawTrajectory
{
    class Program
    {
        static void Main(string[] args)
        {
            MainProcess mainProcess = new MainProcess();
            mainProcess.Start();
            Console.WriteLine("Session successfully run.");
        }
    }
}
