using SearchingAlgorithm;
using System;
using Xunit;
using QueryAlgorithm;

namespace QueryAlgorithm.Tests
{
    public class BinarySearching_GivenArrayShould
    {
        [Theory]
        [InlineData(new int[] { 4, 8, 3, 6, 0, 13, 29, 17 }, 7, false)]
        [InlineData(new int[] { 4, 8, 3, 6, 0, 13, 29, 17 }, 8, true)]
        [InlineData(new int[] { }, 8, false)]
        public void BinarySearch_GivenArray_ReturnBool(int[] inputArray, int queryInt, bool result)
        {
            BinarySearching binarySearching = new BinarySearching(inputArray, queryInt);
            Assert.Equal(binarySearching.BinarySearch(), result);
        }
    }
}
