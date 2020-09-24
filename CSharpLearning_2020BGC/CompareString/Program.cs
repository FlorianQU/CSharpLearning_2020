using System;

namespace CompareString
{
    class Program
    {
        static void Main(string[] args)
        {
            StringComparer stringComparer = new StringComparer();
            Console.WriteLine(stringComparer.CompareString("ABC", "Ican'tsingmyABC"));
            Console.WriteLine(stringComparer.CompareString("abc", "Ican'tsingmyABC"));
        }
    }
}
