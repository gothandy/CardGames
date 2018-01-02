using System;
using Xunit;

namespace CardGamesTest
{
    public class RandomTests
    {
        // Use Zero Seed for running Random tests i.e. for Shuffle
        [Theory]
        [InlineData(1, 37)]
        [InlineData(2, 42)]
        [InlineData(3, 39)]
        [InlineData(4, 29)]
        [InlineData(5, 10)]
        [InlineData(6, 29)]
        [InlineData(7, 47)]
        [InlineData(8, 22)]
        public void RandomSeed(int count, int expected)
        {
            Random random = new Random(0);
            int actual = 0;

            for(int i = 0; i < count; i++)
            {
                actual = random.Next(52);
            }

            Assert.Equal(expected, actual);
        }
    }
}
