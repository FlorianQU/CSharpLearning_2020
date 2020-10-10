using System;
using System.Collections.Generic;

namespace Smoothie
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Smoothie> smoothieList = new List<Smoothie>();
            smoothieList.Add(new Smoothie(new string[] { "Banana" }));
            smoothieList.Add(new Smoothie(new string[] { "Raspberries", "Strawberries", "Blueberries" }));
            smoothieList.Add(new Smoothie(new string[] { "Mango", "Apple", "Pineapple" }));
            smoothieList.Add(new Smoothie(new string[] { "Pineapple", "Strawberries", "Blueberries", "Mango" }));
            smoothieList.Add(new Smoothie(new string[] { "Blueberries" }));
            
            foreach(Smoothie smoothieElement in smoothieList)
            {
                Console.WriteLine("The ingredients are {0}",smoothieElement.Ingredients);
                Console.WriteLine("The cost is {0}",smoothieElement.GetCost());
                Console.WriteLine("The price is {0}", smoothieElement.GetPrice());
                Console.WriteLine("This is a {0}",smoothieElement.GetName());
                Console.WriteLine();
            }
        }
    }
}

