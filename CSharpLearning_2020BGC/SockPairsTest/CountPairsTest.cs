using SockPairs;
using System;
using Xunit;

namespace SockPairsTest
{
    public class CountPairsTest
    {
        [Theory]
        [InlineData("AA", 1)]
        [InlineData("ABABC", 2)]
        [InlineData("CABBACCC", 4)]

        public void CountPairs_Test(string input, int expectedResult)
        {
            SockPairFinder sockPairFinder = new SockPairFinder();
            sockPairFinder.CountSocks(input);
            Assert.Equal(expectedResult, sockPairFinder.CountPairs());
        }
    }
}
