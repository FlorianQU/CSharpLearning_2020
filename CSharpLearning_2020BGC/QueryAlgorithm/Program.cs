using QueryAlgorithm;
using System;

namespace SearchingAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // test Searching
            //int[] searchArray = new int[] { 4, 8, 3, 6, 0, 13, 29, 17 };
            //BinarySearching binSearch = new BinarySearching(searchArray, 8);
            //bool result = binSearch.BinarySearch();
            //Console.WriteLine(result);

            //int[] searchArray = new int[] { 4, 8, 3, 6, 0, 13, 29, 17 };
            //int[] searchArray = new int[] { 4, 8, 3, 6, 0, 13, 8,29, 17 };
            int[] searchArray = new int[] {4 };

            BinaryTreeSearching binaryTreeSearching = new BinaryTreeSearching(searchArray);
            binaryTreeSearching.BuildBinaryTree();
            Console.WriteLine(binaryTreeSearching.Search(10));
            Console.WriteLine(binaryTreeSearching.Search(6));
            binaryTreeSearching.ShowBinaryTree();

        }
    }
}
