using PlayingCardLibrary;
using System;
using Xunit;

namespace CardGamesTest
{
    public class PlayingCardTest
    {
        [Fact]
        public void NewCard()
        {
            Card card = new Card(Rank.Ace, Suit.Spade);

            Assert.Equal("Ace of Spades", card.ToString());
        }

        [Fact]
        public void CardEquals()
        {
            Card card1 = new Card(Rank.Ace, Suit.Spade);
            Card card2 = new Card(Rank.Ace, Suit.Spade);

            Assert.Equal<Card>(card1, card2);
        }

        [Fact]
        public void CardHash()
        {
            Card card = new Card(Rank.Ace, Suit.Spade);

            Assert.Equal<int>(1, card.GetHashCode());
        }

        [Fact]
        public void NewPackCount()
        {
            Pack pack = new Pack();

            Assert.Equal(52, pack.Count);
        }

        [Fact]
        public void NewPackBottomCard()
        {
            Pack pack = new Pack();

            Assert.Equal<Card>(new Card(Rank.Ace, Suit.Spade), pack[0]);
        }

        [Fact]
        public void NewPackTopCard()
        {
            Pack pack = new Pack();

            Assert.Equal<Card>(new Card(Rank.King, Suit.Heart), pack[51]);
        }


    }
}
