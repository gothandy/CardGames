using CardGames;
using System;
using Xunit;

namespace CardGames
{
    public class PackTests
    {

        [Theory]
        [InlineData(52)]
        public void Count(int count)
        {
            Pack pack = new Pack();

            Assert.Equal(count, pack.Count);
        }

        [Fact]
        public void OrientationFaceDown()
        {
            Pack pack = new Pack();

            Assert.Equal(Orientation.FaceDown, pack.Orientation);
        }


        [Theory]
        [InlineData(0, Rank.Ace, Suit.Spade)]
        [InlineData(1, Rank.Two, Suit.Spade)]
        [InlineData(50, Rank.Queen, Suit.Heart)]
        [InlineData(51, Rank.King, Suit.Heart)]
        public void NewPack(int index, Rank rank, Suit suit)
        {
            Pack pack = new Pack();

            Assert.Equal<Card>(new Card(rank, suit), pack[index]);
        }
    }
}
