using PlayingCardLibrary;
using System;
using Xunit;

namespace CardGamesTest
{
    public class PackTests
    {

        [Fact]
        public void Count()
        {
            Pack pack = new Pack();

            Assert.Equal(52, pack.Count);
        }

        [Fact]
        public void OrientationFaceDown()
        {
            Pack pack = new Pack();

            Assert.Equal(Orientation.FaceDown, pack.Orientation);
        }


        [Theory]
        [InlineData(Rank.Ace, Suit.Spade, 0)]
        [InlineData(Rank.Two, Suit.Spade, 1)]
        [InlineData(Rank.Queen, Suit.Heart, 50)]
        [InlineData(Rank.King, Suit.Heart, 51)]
        public void BottomCard(Rank rank, Suit suit, int index)
        {
            Pack pack = new Pack();

            Assert.Equal<Card>(new Card(rank, suit), pack[index]);
        }
    }
}
