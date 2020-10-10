using System;
using Xunit;
using CompareString;

namespace CompareStringTest
{
    public class CompareStringTest
    {
        [Theory]
        [InlineData("ABC", "Ican'tsingmyABC", true)]
        [InlineData("abc", "Ican'tsingmyABC", true)]
        [InlineData("Ican'tsingmyABC", "abc", true)]
        [InlineData("hello world", "hello", false)]
        [InlineData("+=", "this should work too +=", true)]
        [InlineData("hey", "*********", true)]

        public void CompareString_Test(string str1, string str2, bool expectedResult)
        {
            CompareString.StringComparer stringComparer = new CompareString.StringComparer();
            Assert.Equal(expectedResult, stringComparer.CompareString(str1, str2));
        }
    }
}
