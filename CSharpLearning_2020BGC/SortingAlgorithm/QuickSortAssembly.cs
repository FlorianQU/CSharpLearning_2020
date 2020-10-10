using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithm
{
    // Unstable
    public class QuickSortAssembly
    {
        public void QuickSortAscending(int[] inputArray, int low, int high)
        {
            int i = low;
            int j = high;
            if (i >= j)
            {
                return;
            }
            else
            {
                int key = inputArray[i];
                while (i < j)
                {
                    while (inputArray[j] >= key && j > i)
                    {
                        j--;
                    }
                    inputArray[i] = inputArray[j];
                    while (inputArray[i] <= key && i < j)
                    {
                        i++;
                    }
                    inputArray[j] = inputArray[i];
                }
                inputArray[i] = key;
                QuickSortAscending(inputArray, low, i - 1);
                QuickSortAscending(inputArray, i + 1, high);
            }

        }
        public void QuickSortDescending(int[] inputArray, int low, int high)
        {
            int i = low;
            int j = high;
            if (i >= j)
            {
                return;
            }
            else
            {
                int key = inputArray[i];
                while (i < j)
                {
                    while (inputArray[j] <= key && j > i)
                    {
                        j--;
                    }
                    inputArray[i] = inputArray[j];
                    while (inputArray[i] >= key && i < j)
                    {
                        i++;
                    }
                    inputArray[j] = inputArray[i];
                }
                inputArray[i] = key;
                QuickSortDescending(inputArray, low, i - 1);
                QuickSortDescending(inputArray, i + 1, high);
            }
        }
    }
}