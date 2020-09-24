using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithm
{
    // Unstable
    public class HeapSortAssembly
    {
        public int[] InputArray { get; }
        public HeapSortAssembly(int[] inputArray)
        {
            InputArray = inputArray;
        }
        public void swap(int i, int j)
        {
            int temp = InputArray[i];
            InputArray[i] = InputArray[j];
            InputArray[j] = temp;
        }
        // Ascending Method
        private void HeapifyAscending(int index, int length)
        {
            int leftLeave = 2 * index + 1;
            int rightLeave = leftLeave + 1;
            int maxIndex = leftLeave;
            if (leftLeave > length)
            {
                return;
            }
            else
            {
                if (rightLeave <= length && InputArray[rightLeave] > InputArray[leftLeave])
                {
                    maxIndex = rightLeave;
                }
                if (InputArray[maxIndex] > InputArray[index])
                {
                    swap(maxIndex, index);
                    HeapifyAscending(maxIndex, length);
                }
            }
        }
        public void HeapSortAscending()
        {
            int length = InputArray.Length;
            int startIndex = length / 2 - 1;
            for (int i = startIndex; i >= 0; i--)
            {
                HeapifyAscending(i, length - 1);
            }
            for (int i = length - 1; i > 0; i--)
            {
                swap(0, i);
                HeapifyAscending(0, i - 1);
            }
        }
        // Descending Method
        private void HeapifyDescending(int index, int length)
        {
            int leftLeave = 2 * index + 1;
            int rightLeave = leftLeave + 1;
            int minIndex = leftLeave;
            if (leftLeave > length)
            {
                return;
            }
            else
            {
                if (rightLeave <= length && InputArray[rightLeave] < InputArray[leftLeave])
                {
                    minIndex = rightLeave;
                }
                if (InputArray[minIndex] < InputArray[index])
                {
                    swap(minIndex, index);
                    HeapifyDescending(minIndex, length);
                }
            }
        }
        public void HeapSortDescending()
        {
            int length = InputArray.Length;
            int startIndex = length / 2 - 1;
            for (int i = startIndex; i >= 0; i--)
            {
                HeapifyDescending(i, length - 1);
            }
            for (int i = length - 1; i > 0; i--)
            {
                swap(0, i);
                HeapifyDescending(0, i - 1);
            }
        }
    }
}
