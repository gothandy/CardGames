using CardGames;
using System;
using Xunit;

namespace CardGamesTest
{
    public class CardTests
    {
        [Fact]
        public void NewTest()
        {
            Card card = new Card(Rank.Ace, Suit.Spade);

            Assert.Equal("Ace of Spades", card.ToString());
        }

        [Fact]
        public void EqualsTest()
        {
            Card card1 = new Card(Rank.Ace, Suit.Spade);
            Card card2 = new Card(Rank.Ace, Suit.Spade);

            Assert.Equal<Card>(card1, card2);
        }

        [Fact]
        public void NotEqualsTest()
        {
            Card card1 = new Card(Rank.Ace, Suit.Spade);
            Card card2 = new Card(Rank.Two, Suit.Spade);

            Assert.NotEqual<Card>(card1, card2);
        }

        [Fact]
        public void HashTest()
        {
            Card card = new Card(Rank.Ace, Suit.Spade);

            Assert.Equal<int>(1, card.GetHashCode());
        }
    }
}
