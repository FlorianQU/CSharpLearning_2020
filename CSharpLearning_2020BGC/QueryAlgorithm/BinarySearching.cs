using System;
using System.Collections.Generic;
using System.Text;
using SortingAlgorithm;

namespace SearchingAlgorithm
{
    public class BinarySearching
    {
        public int[] CopyArray { get; }
        public int Query { get; set; }
        public BinarySearching(int[] inputArray, int query)
        {
            int[] copyArray = new int[inputArray.Length];
            inputArray.CopyTo(copyArray, 0);
            QuickSortAssembly sortAssembly = new QuickSortAssembly();
            sortAssembly.QuickSortAscending(copyArray, 0, copyArray.Length - 1);
            CopyArray = copyArray;
            Query = query;
        }
        public bool BinarySearch()
        {
            return SearchingWhileDividing(0, CopyArray.Length - 1);
        }
        private bool SearchingWhileDividing(int low, int high)
        {
            if (low < high)
            {
                if (CopyArray[low] == Query || CopyArray[high] == Query)
                {
                    return true;
                }
                else if (Query > CopyArray[low] && Query < CopyArray[high])
                {
                    int midIndex = (low + high) / 2 + 1;
                    if (Query >= CopyArray[midIndex])
                    {
                        return SearchingWhileDividing(midIndex, high);
                    }
                    else
                    {
                        return SearchingWhileDividing(low, midIndex - 1);
                    }
                }
            }
            return false;

        }
    }
}
