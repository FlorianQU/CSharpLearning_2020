using System;
using System.Collections.Generic;
using System.Text;

namespace Smoothie
{
    public class Smoothie
    {
        private static readonly Dictionary<string, double> priceList = new Dictionary<string, double>
        {
            {"Strawberries",1.5 },
            {"Banana",0.5 },
            {"Mango",2.5 },
            {"Blueberries",1.0 },
            {"Raspberries",1.0 },
            {"Apple",1.75 },
            {"Pineapple",3.5 }
        };
        private static readonly Dictionary<string, string> nameList = new Dictionary<string, string>
        {
            {"Strawberries","Strawberry"},
            {"Banana","Banana"},
            {"Mango","Mango"},
            {"Blueberries","Blueberry"},
            {"Raspberries","Raspberry"},
            {"Apple","Apple"},
            {"Pineapple","Pineapple"}
        };
        public string[] Ingredients { get; set; }
        public Smoothie(string[] ingredients)
        {
            Ingredients = ingredients;
        }
        public double GetCost()
        {
            double cost = 0;
            foreach (string ingredient in Ingredients)
            {
                cost += priceList[ingredient];
            }
            return cost;
        }
        public double GetPrice()
        {
            double cost = GetCost();
            return Math.Round(cost * 2.5, 2);
        }
        public string GetName()
        {
            string[] sortedIngredientsList = new string[Ingredients.Length];
            string endString = "";
            Ingredients.CopyTo(sortedIngredientsList, 0);
            Array.Sort(sortedIngredientsList);
            string nameString = "";
            foreach (string nameElement in sortedIngredientsList)
            {
                nameString = String.Format("{0}{1} ", nameString, nameList[nameElement]);
            }
            if (sortedIngredientsList.Length > 1)
            {
                endString = "Fusion";
            }
            else
            {
                endString = "Smoothie";
            }
            nameString = String.Format("{0}{1}", nameString, endString);
            return nameString.ToString();
        }
    }
}
