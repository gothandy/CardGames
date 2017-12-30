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
        public void NewPack()
        {
            Pack pack = new Pack();

            Assert.Equal(52, pack.Count);
            Assert.Equal<Card>(new Card(Rank.Ace, Suit.Spade), pack[0]);
        }
    }
}
