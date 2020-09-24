using System;

namespace LeastCommonMultiple
{
    class Program
    {
        static void Main(string[] args)
        {
            LeastCommonMultiple lCM = new LeastCommonMultiple();
            int result = lCM.LCM(new int[] { 73, 74, 75, 76, 77 });
            Console.WriteLine("{0}", result);
        }
    }
}
