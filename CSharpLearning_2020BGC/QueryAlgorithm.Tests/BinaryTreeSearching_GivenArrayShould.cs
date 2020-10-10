using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace QueryAlgorithm.Tests
{
    public class BinaryTreeSearching_GivenArrayShould
    {
        [Theory]
        [InlineData(new int[] { }, 3, false)]
        [InlineData(new int[] { 4, 8, 3, 6, 0, 13, 29, 17 }, 3, true)]
        [InlineData(new int[] { 4, 8, 3, 6, 0, 13, 29, 17, 6, 8 }, 7, false)]
        [InlineData(new int[] { 5 }, 3, false)]
        [InlineData(new int[] { 6, 2 }, 3, false)]
        public void BinaryTreeSearching_GivenArray_ReturnBool(int[] inputArray, int queryInt, bool result)
        {
            BinaryTreeSearching binaryTreeSearching = new BinaryTreeSearching(inputArray);
            binaryTreeSearching.BuildBinaryTree();
            Assert.Equal(binaryTreeSearching.Search(queryInt), result);
        }
    }
}
