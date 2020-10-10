using System;
using System.Collections.Generic;
using System.Text;

namespace MaxMin
{
    public class MaxMinTest
    {
        public long[] MaxMin(long inputNumber)
        {
            char[] charArray = inputNumber.ToString().ToCharArray();
            long Max = ToMax(charArray, 0);
            charArray = inputNumber.ToString().ToCharArray();
            long Min = ToMin(charArray, 0);
            return new long[] { Max, Min };
        }
        private long ToMax(char[] charArray, int startIndex)
        {
            if (startIndex == charArray.Length - 1)
            {
                return long.Parse(new string(charArray));
            }
            else
            {
                int maxIndex = getMax(charArray, startIndex);
                if (charArray[startIndex] < charArray[maxIndex])
                {
                    char maxValue = charArray[maxIndex];
                    charArray[maxIndex] = charArray[startIndex];
                    charArray[startIndex] = maxValue;
                    return long.Parse(new string(charArray));
                }
                else
                {
                    return ToMax(charArray, startIndex + 1);
                }
            }
        }
        private long ToMin(char[] charArray, int startIndex)
        {
            if (startIndex == charArray.Length - 1)
            {
                return long.Parse(new string(charArray));
            }
            else
            {
                int minIndex = getMin(charArray, startIndex);
                if (minIndex == -1)
                {
                    return long.Parse(new string(charArray));
                }
                else if (charArray[startIndex] > charArray[minIndex])
                {
                    char minValue = charArray[minIndex];
                    charArray[minIndex] = charArray[startIndex];
                    charArray[startIndex] = minValue;
                    return long.Parse(new string(charArray));
                }
                else
                {
                    return ToMin(charArray, startIndex + 1);
                }
            }
        }
        private int getMax(char[] charArray, int startIndex)
        {
            char initialChar = '0';
            int initialIndex = startIndex + 1;
            for (int i = startIndex + 1; i < charArray.Length; i++)
            {
                if (charArray[i] >= initialChar)
                {
                    initialIndex = i;
                    initialChar = charArray[i];
                }
            }
            return initialIndex;
        }
        private int getMin(char[] charArray, int startIndex)
        {
            char initialChar = '9';
            int initialIndex;
            if (startIndex == 0)
            {
                initialIndex = -1;
                for (int i = startIndex + 1; i < charArray.Length; i++)
                {
                    if (charArray[i] <= initialChar && charArray[i] > '0')
                    {
                        initialChar = charArray[i];
                        initialIndex = i;
                    }
                }
            }
            else
            {
                initialIndex = startIndex + 1;
                for (int i = startIndex + 1; i < charArray.Length; i++)
                {
                    if (charArray[i] <= initialChar)
                    {
                        initialIndex = i;
                        initialChar = charArray[i];
                    }
                }
            }
            return initialIndex;
        }
    }
}
