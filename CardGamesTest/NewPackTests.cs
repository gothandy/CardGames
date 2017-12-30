using PlayingCardLibrary;
using System;
using Xunit;

namespace CardGamesTest
{
    public class NewPackTests
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


        [Fact]
        public void BottomCard()
        {
            Pack pack = new Pack();

            Assert.Equal<Card>(new Card(Rank.Ace, Suit.Spade), pack[0]);
        }

        [Fact]
        public void TopCard()
        {
            Pack pack = new Pack();

            Assert.Equal<Card>(new Card(Rank.King, Suit.Heart), pack[51]);
        }

        [Fact]
        public void SecondBottomCard()
        {
            Pack pack = new Pack();

            Assert.Equal<Card>(new Card(Rank.Two, Suit.Spade), pack[1]);
        }

        [Fact]
        public void SecondTopCard()
        {
            Pack pack = new Pack();

            Assert.Equal<Card>(new Card(Rank.Queen, Suit.Heart), pack[50]);
        }
    }
}
