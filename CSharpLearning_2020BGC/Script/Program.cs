using System;
using System.Collections.Generic;
using System.Linq;

namespace Script
{
    class Program
    {
        static void Main(string[] args)
        {
            //IEnumerable<char> query = "How are you, friend.";

            //foreach (char vowel in "aeiou")
            //    query = query.Where(c => c != vowel);

            //foreach (char c in query) Console.Write(c);
            //Action[] actions = new Action[3];

            //for (int i = 0; i < 3; i++)
            //{
            //    actions[i] = () => Console.Write(i);
            //    Console.WriteLine(i);

            //}
            //foreach (Action a in actions) a();   // both C# 4.0 and 5.0: 333

            //Program program = new Program();
            //int newnum = 5;
            //int num = 6;
            ////program.Change(num);
            //Change();
            //Console.WriteLine(num);
            //Console.WriteLine(newnum);
            //Console.WriteLine('\\');
            //void Change()
            //{
            //    newnum = newnum - 1;
            //    num = num + 1;
            //}
            //char[] newArray = new char[3];
            //foreach (char element in newArray)
            //{
            //    Console.WriteLine($"Content is {element}.");
            //}
            //int[,] newArray = new int[3, 2];
            //newArray[1, 0] = 1;
            //newArray[2, 0] = 2;
            //for (int i = 0; i < newArray.GetLength(0); i++)
            //{
            //    for (int j = 0; j < newArray.GetLength(1); j++)
            //    {
            //        Console.Write($"{newArray[i, j]},");
            //    }
            //    Console.WriteLine();
            //}
            //float i = float.Parse("37.1");
            //Console.WriteLine(i);
            string[] newstr = new string[3];
            foreach(string element in newstr)
            {
                Console.WriteLine(element == null);
            }


        }



    }
}
