using System;
using System.Collections.Generic;

namespace MaxMin
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxMinTest testClass = new MaxMinTest();
            List<long> inputList = new List<long>();
            inputList.Add(12340);
            inputList.Add(98761);
            inputList.Add(9000);
            inputList.Add(11321);

            foreach (long inputElement in inputList)
            {
                long[] output = testClass.MaxMin(inputElement);
                Console.WriteLine("The results are {0} and {1}.",output[0],output[1]);
            }
        }
    }
}
