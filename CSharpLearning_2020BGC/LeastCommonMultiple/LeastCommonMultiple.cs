using System;
using System.Collections.Generic;
using System.Text;

namespace LeastCommonMultiple
{
    public class LeastCommonMultiple
    {
        private int GreatestCommonDivisor(int num1, int num2)
        {
            if (num1 == num2)
            {
                return num1;
            }
            else if (num1 < num2)
            {
                return GreatestCommonDivisor(num1, num2 - num1);
            }
            else
            {
                return GreatestCommonDivisor(num1 - num2, num2);
            }

        }
        private int GetLeastCommonMultiple(int num1, int num2)
        {

            return num2 / GreatestCommonDivisor(num1, num2) * num1;
        }
        public int LCM(int[] inputList)
        {
            int i = 0;
            int leastCommonMultiple = inputList[0];
            while (i < inputList.Length - 1)
            {
                i++;
                leastCommonMultiple = GetLeastCommonMultiple(leastCommonMultiple, inputList[i]);
            }
            return leastCommonMultiple;
        }
    }
}
