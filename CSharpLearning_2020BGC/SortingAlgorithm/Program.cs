using System;

namespace SortingAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            //Testing Quicksort method.
            Console.WriteLine("Testing QuickSort method.");
            QuickSortAssembly quickSort = new QuickSortAssembly();
            int[] testArray = new int[] { 4, 7, 3, 6, 0, 13, 29, 17 };
            Console.Write("Original array: ");
            foreach (int element in testArray)
            {
                Console.Write($"{element},");
            }
            Console.WriteLine();

            quickSort.QuickSortAscending(testArray, 0, testArray.Length - 1);
            Console.Write("Sorted array in ascending order: ");
            foreach (int element in testArray)
            {
                Console.Write($"{element},");
            }
            Console.WriteLine();

            testArray = new int[] { 4, 7, 3, 6, 0, 13, 29, 17 };
            quickSort.QuickSortDescending(testArray, 0, testArray.Length - 1);
            Console.Write("Sorted array in descending order: ");
            foreach (int element in testArray)
            {
                Console.Write($"{element},");
            }
            Console.WriteLine();

            //Testing Heapsort method.
            Console.WriteLine();
            Console.WriteLine("Testing HeapSort method.");
            testArray = new int[] { 4, 7, 3, 6, 0, 13, 29, 17 };
            HeapSortAssembly heapsort = new HeapSortAssembly(testArray);
            Console.Write("Original array: ");
            foreach (int element in testArray)
            {
                Console.Write($"{element},");
            }
            Console.WriteLine();

            heapsort.HeapSortAscending();
            Console.Write("Sorted array in ascending order: ");
            foreach (int element in testArray)
            {
                Console.Write($"{element},");
            }
            Console.WriteLine();

            testArray = new int[] { 4, 7, 3, 6, 0, 13, 29, 17 };
            heapsort = new HeapSortAssembly(testArray);
            heapsort.HeapSortDescending();
            Console.Write("Sorted array in descending order: ");
            foreach (int element in testArray)
            {
                Console.Write($"{element},");
            }
            Console.WriteLine();
            #endregion

        }
    }
}
