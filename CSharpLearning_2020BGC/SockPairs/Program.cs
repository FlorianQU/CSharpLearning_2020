using System;
using System.IO;
namespace SockPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            SockPairFinder finder = new SockPairFinder();
            string input = Console.ReadLine();
            while(input!= null)
            {
                finder.CountSocks(input);
                int pairs = finder.CountPairs();
                Console.WriteLine("Includes {0} pairs of socks.", pairs);
                input = Console.ReadLine();
            }
            
        }
    }
}
